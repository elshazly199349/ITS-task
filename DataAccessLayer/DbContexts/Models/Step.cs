using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [InverseProperty("Step")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
