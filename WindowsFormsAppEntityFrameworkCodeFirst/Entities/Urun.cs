using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Urunler")]
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }
        public int Stok { get; set; }
    }
}
