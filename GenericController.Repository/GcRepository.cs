using System.Linq;
using Microsoft.EntityFrameworkCore;
using GenericController.Repository.Contracts;
using GenericController.Repository.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GenericController.Repository
{
    public class GcRepository : IGcRepository
    {
        private readonly GenericControllerContext _dbContext;

        public GcRepository(GenericControllerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<string> RetrieveFormScriptAsync(long formId)
        {
            return _dbContext.Forms.Where(m => m.ID == formId).Select(m => m.Script).SingleOrDefaultAsync();
        }

        public Task<List<FormInputList>> RetrieveFormInputsAsync(long formId)
        {
            Task<List<FormInputList>> inputs = _dbContext.FormInputs
                                 .Where(m => m.FormID == formId && m.IsActive)
                                 .OrderBy(m => m.Order)
                                 .Include(m => m.Input)
                                 .ThenInclude(m => m.InputProperty)
                                  .Select(
                                     m =>
                                         new FormInputList
                                         {
                                             Id = m.ID,
                                             //InputId = m.InputID,
                                             ParentId = m.ParentID,
                                             Type = m.Input.Type,
                                             InputProperties = m.Input.InputProperty.ToList()
                                         }
                                 ).ToListAsync();

            return inputs;
        }
    }
}