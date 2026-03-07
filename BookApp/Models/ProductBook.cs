using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class ProductBook{
        [Display(Name="Id")]
        public int BookId{get;set;}

        [Display(Name="Kitap Adı")]
        [Required(ErrorMessage = "Kitap Adı alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kitap Adı 100 karakteri geçemez.")]
        public string? BookName {get;set;}

        [Display(Name="Sayfa Sayısı")]
        [Required(ErrorMessage = "Sayfa Sayısı alanı zorunludur.")]
        [Range(1, 10000, ErrorMessage = "Sayfa Sayısı 1 ile 10000 arasında olmalıdır.")]
        public int PageCount {get;set;}

        [Display(Name="Resim")]
        public string? Image {get;set;}

        [Display(Name="Aktif")]
        public bool IsActive {get;set;}

        [Display(Name="Kategori")]
        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int CategoryId {get;set;}

        [Display(Name="Fiyat")]
        public decimal? Price {get;set;}

        [Display(Name="Özet")]
        public string? Description {get;set;}
    }
}