using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericController.Repository.Entities
{
    public class FormInputEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [ForeignKey("Form")]
        public long FormID { get; set; }

        [Required]
        [ForeignKey("Input")]
        public long InputID { get; set; }

        [Required]
        public short Order { get; set; }

        [ForeignKey("FormInput")]
        public long? ParentID { get; set; }

        public bool IsActive { get; set; }

        public virtual FormEntity Form { get; set; }

        public virtual InputEntity Input { get; set; }

        public virtual FormInputEntity Parent { get; set; }

        //public virtual ICollection<FormInput> InverseParent { get; set; }
    }
}