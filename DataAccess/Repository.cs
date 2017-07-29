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


            //var res = _dbContext.FormInput.Where(m => m.FormID == formId)
            //    .Include(m => m.Input)
            //    .ThenInclude(m => m.InputProperty)
            //    .Select(m =>
            //    new
            //    {
            //        Id = m.ID,
            //        //InputId = m.InputID,
            //        ParentId = m.ParentID,
            //        Type = m.Input.Type,
            //        PropertyName = m.Input.InputProperty.FirstOrDefault().PropertyName,
            //        PropertyValue = m.Input.InputProperty.FirstOrDefault().PropertyValue
            //    });


            var query =
                (_dbContext.FormInput.Where(m => m.FormID == formId && m.IsActive == true).OrderBy(m => m.Order)
                .Join
                (
                    _dbContext.Input,
                    fi => fi.InputID,
                    i => i.ID,
                    (fi, i) =>
                    new
                    {
                        ID = fi.ID,
                        InputID = fi.InputID,
                        ParentID = fi.ParentID,
                        Type = i.Type
                    }
                ));


            var formInputs = new List<dynamic>();

            foreach (var formInput in query)
            {
                var inputProperties = RetrieveInputProperties(formInput.InputID);

                if (inputProperties.Any())
                {
                    foreach (var ip in inputProperties)
                    {
                        formInputs.Add(new
                        {
                            Id = formInput.ID,
                            InputId = formInput.InputID,
                            ParentId = formInput.ParentID,
                            Type = formInput.Type,
                            PropertyName = ip.PropertyName,
                            PropertyValue = ip.PropertyValue
                        });
                    }
                }
                else
                {
                    formInputs.Add(new
                    {
                        Id = formInput.ID,
                        InputId = formInput.InputID,
                        ParentId = formInput.ParentID,
                        Type = formInput.Type,
                        PropertyName = string.Empty,
                        PropertyValue = string.Empty
                    });
                }
            }

            return formInputs;
        }

        private IEnumerable<InputProperty> RetrieveInputProperties(long inputId)
        {
            var query = _dbContext.InputProperty.Where(m => m.InputID == inputId);

            return query;
        }
    }
}