using GenericVC.Context;
using GenericVC.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GenericVC.DataAccess
{
    public class Repository : IRepository
    {
        private readonly GenericVCContext _dbContext;

        public Repository(GenericVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string RetrieveForm(long formId)
        {
            return _dbContext.Form.Single(m => m.ID == formId).Script;
        }

        public dynamic RetrieveFormInputs(long formId)
        {
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