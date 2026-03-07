using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
   public class Category
    {
        [Display(Name="Id")]
        public int CategoryId { get; set;}

        [Display(Name="Kategori Adı")]
        [Required(ErrorMessage = "Kategori Adı zorunludur.")]
        public string? Name { get; set; }
    }
}
