namespace GenericController.DataAccess
{
    public interface IRepository
    {
        string RetrieveForm(long formId);
        dynamic RetrieveFormInputs(long formId);
        //dynamic RetrieveInputProperties(long inputId);
    }
}
