using GenericController.Entities;

namespace GenericController.Repository
{
    public interface IGcRepository
    {
        string RetrieveForm(long formId);
        View RetrieveFormInputs(long formId);
    }
}
