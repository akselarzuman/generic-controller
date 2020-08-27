using System.Collections.Generic;
using System.Threading.Tasks;
using GenericController.Repository.Entities;

namespace GenericController.Repository.Contracts
{
    public interface IGcRepository
    {
        Task<string> RetrieveFormScriptAsync(long formId);

        Task<List<FormInputList>> RetrieveFormInputsAsync(long formId);
    }
}
