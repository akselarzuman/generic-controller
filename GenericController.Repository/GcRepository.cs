using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GenericController.Entities;

namespace GenericController.Repository
{
    public class GcRepository : IGcRepository
    {
        private readonly GenericControllerContext _dbContext;

        public GcRepository(GenericControllerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string RetrieveForm(long formId)
        {
            return _dbContext.Form.Single(m => m.ID == formId).Script;
        }

        public View RetrieveFormInputs(long formId)
        {
           var inputs = _dbContext.FormInput
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
                ).ToList();

                return new View
                {
                    Inputs = inputs,
                    Form=new Form()
                };
        }

        private IEnumerable<InputProperty> RetrieveInputProperties(long inputId)
        {
            var query = _dbContext.InputProperty.Where(m => m.InputID == inputId);

            return query;
        }
    }
}