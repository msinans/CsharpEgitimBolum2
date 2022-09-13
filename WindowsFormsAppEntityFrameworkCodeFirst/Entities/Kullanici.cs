using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        public int Id { get; set; }
        public int TCNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
    }
}
