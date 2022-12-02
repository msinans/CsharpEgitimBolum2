using System;

namespace AspNetFrameworkMVC.Models
{
    public class Uye
    {
        public int Id { get; set; }

        public String Ad { get; set; }

        public String Soyad { get; set; }

        public String Email { get; set; }
        public String Telefon { get; set; }
        public String TcKimlikNo { get; set; }
        public DateTime KayitTarihi { get; set; }
        public String KullaniciAdi { get; set; }
        public String Sifre { get; set; }
        public String SifreTekrar { get; set; }
    }
}