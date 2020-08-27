using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericController.Repository.Entities
{
    public class InputPropertyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [ForeignKey("Input")]
        public long InputID { get; set; }
        
        [Required]
        public string PropertyName { get; set; }
        
        [Required]
        public string PropertyValue { get; set; }

        public virtual InputEntity Input { get; set; }
    }
}