using System.Collections.Generic;

namespace GenericController.Repository.Entities
{
    public class View
    {
        public FormEntity Form{get;set;}

        //public string Script { get; set; }
        
        public List<FormInputList> Inputs { get; set; }
    }
}