namespace GenericVC.Models
{
    public class FormInputList
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public long ParentId { get; set; }
    }
}
