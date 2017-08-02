using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericController.Entities
{
    public class Form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID{get;set;}
        [Required]
        public string Name { get; set; }
        public string Script { get; set; }

        public virtual ICollection<FormInput> FormInput { get; set; }
    }
}