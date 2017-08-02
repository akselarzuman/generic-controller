namespace GenericController.Repository
{
    public interface IGcRepository
    {
        string RetrieveForm(long formId);
        dynamic RetrieveFormInputs(long formId);
    }
}
