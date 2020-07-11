using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("Step")]
        public int StepId { get; set; }

        [ForeignKey("StepId")]
        [InverseProperty("Items")]
        public virtual Step Step { get; set; }
    }
}
