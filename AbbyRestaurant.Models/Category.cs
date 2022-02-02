using System.ComponentModel.DataAnnotations;

namespace AbbyRestaurant.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Display Order")]
        [Range(0,1000,ErrorMessage ="Display Order must be in range of 1-1000")]
        public int DisplayOrder { get; set; }
    }
}
