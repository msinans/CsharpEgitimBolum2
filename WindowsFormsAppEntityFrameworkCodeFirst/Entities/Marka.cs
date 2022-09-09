using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Markalar")] // veritabanında tablo adı markas yerine markalar olsun
    public class Marka // Projemizdeki entities klasörüne sağ tıklayıp and class ile bu sınıfı ekledikten sonra property lerini tanımladık
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        // Property  lerimizi tanımladıktan sonra bu sınıfın veritabanı işlemlerini yapabilmek için Databasecontext classına marka classını dbset olarak eklememiz gerekir.
    }
}
