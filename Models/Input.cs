using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericController.Models
{
    public class Input
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }


        public virtual ICollection<FormInput> FormInput { get; set; }
        public virtual ICollection<InputProperty> InputProperty { get; set; }
    }
}