using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        public DateTime isCreated { get; set; } = DateTime.Now;
        [Required]
        public DateTime isModified { get; set; } = DateTime.Now;
        public int? ParentCategoryId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Values { get; set; }
    }
}
