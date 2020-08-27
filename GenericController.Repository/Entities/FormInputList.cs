using System.Collections.Generic;

namespace GenericController.Repository.Entities
{
    public class FormInputList
    {
        public long Id { get; set; }

        public string Type { get; set; }
        
        public List<InputPropertyEntity> InputProperties { get; set; }
        
        public long? ParentId { get; set; }
    }
}
