using System;
using System.ComponentModel.DataAnnotations; // Validation işlemleri çin gerekli kütüphane

namespace AspNetFrameworkMVC.Models
{
    public class Uye
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public String Ad { get; set; }
        [Required, StringLength(50)]
        public String Soyad { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        [Phone]
        public String Telefon { get; set; }
        [Display(Name = "Tc Kimlik Numarası")]
        [MinLength(11, ErrorMessage = "Tc Kimlik Numarası 11 Karakter Olmalıdır!")]
        [MaxLength(11, ErrorMessage = "{0} 11 Karakter Olmalıdır!")]
        public String TcKimlikNo { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public String KullaniciAdi { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password)]
        [Required, StringLength(50, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 3)]
        public String Sifre { get; set; }
        [Display(Name = "Şifre Tekrar"), DataType(DataType.Password)]
        [Compare("Sifre")]
        public String SifreTekrar { get; set; }
    }
}