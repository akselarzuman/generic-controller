using System.Collections.Generic;
using System.Linq;
using GenericController.Context;
using GenericController.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericController.DataAccess
{
    public class Repository : IRepository
    {
        private readonly GenericControllerContext _dbContext;

        public Repository(GenericControllerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string RetrieveForm(long formId)
        {
            return _dbContext.Form.Single(m => m.ID == formId).Script;
        }

        public dynamic RetrieveFormInputs(long formId)
        {
           return _dbContext.FormInput
                .Where(m => m.FormID == formId && m.IsActive)
                .OrderBy(m => m.Order)
                .Include(m => m.Input)
                .ThenInclude(m => m.InputProperty)
                 .Select(
                    m =>
                        new
                        {
                            Id = m.ID,
                            //InputId = m.InputID,
                            ParentId = m.ParentID,
                            Type = m.Input.Type,
                            InputProperties = m.Input.InputProperty
                        }
                );
        }

        private IEnumerable<InputProperty> RetrieveInputProperties(long inputId)
        {
            var query = _dbContext.InputProperty.Where(m => m.InputID == inputId);

            return query;
        }
    }
}