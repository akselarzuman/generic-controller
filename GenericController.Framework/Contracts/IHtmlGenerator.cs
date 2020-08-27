using GenericController.Repository.Entities;

namespace GenericController.Framework.Contracts
{
    public interface IHtmlGenerator
    {
        string GenerateForm(View view);
    }
}