using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Kategoriler")] // EF ün veritabanı tablosunu Kategoris ismi yerine Kategoriler olarak oluşturmaı için bu attribute 
    public class Kategori
    {
        
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
    }
}
