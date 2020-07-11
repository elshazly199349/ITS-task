using System.ComponentModel.DataAnnotations;

namespace DomainModels.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StepId { get; set; }
    }
}
