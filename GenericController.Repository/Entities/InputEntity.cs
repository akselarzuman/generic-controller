using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericController.Repository.Entities
{
    public class InputEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public string Type { get; set; }
        
        [Required]
        public string Description { get; set; }

        public virtual ICollection<FormInputEntity> FormInput { get; set; }

        public virtual ICollection<InputPropertyEntity> InputProperty { get; set; }
    }
}