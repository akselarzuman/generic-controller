using System.Collections.Generic;

namespace GenericController.Entities
{
    public class View
    {
        public Form Form{get;set;}
        //public string Script { get; set; }
        public List<FormInputList> Inputs { get; set; }
    }
}