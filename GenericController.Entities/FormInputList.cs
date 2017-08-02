using System.Collections.Generic;

namespace GenericController.Entities
{
    public class FormInputList
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public List<InputProperty> InputProperties { get; set; }
        public long ParentId { get; set; }
    }
}
