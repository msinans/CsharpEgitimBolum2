using System;
using System.Collections.Generic;
using System.Linq;
using System.Data; //Veritabanı işlemi için gerekli
using System.Data.SqlClient; //AdoNet kütüphaneleri olarak düzenleyelim

namespace WindowsFormsAppAdoNet
{
    public class ProductDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet;integrated security= true"); //Veritabanınan bağlanmak için kullandığımız ado net sınıfıdır. Parametre olarak kendisine verilen bilgilerdeki veritabanına bağlanır.
        void ConnectionKontrol()
        {
            if (connection.State == ConnectionState.Closed) //Eğer yukarıdaki veritabanı bağlantısı kapalıysa
            {
                connection.Open(); // bağlantıyı aç
            }
        }
        public List<Product> GetAll() // Bu metodun geri dönüş değeri List<Product> yani ürün listesidir.
        {
            ConnectionKontrol(); // Metot çalıştığı anda bağlantıyı kontrol et
            List<Product> products = new List<Product>(); // Geriye döndüreceğimiz List<Product> nesnesi oluşturduk.
            SqlCommand command = new SqlCommand("select * from Products", connection); // SqlCommand sql komutlarını çalıştırabilmemizi sağlayan ado net sınıfıdır. Tırnaklar içerisinie sql komutumuzu, sonraki parametrede de bu komutun çalıştıracağı connection nesnesini belirtiyoruz.
            SqlDataReader reader = command.ExecuteReader(); // SqlDataReader Sql veri okuyucu sınıfıdır, bu sınıfa üstteki command nesnesini ExecuteReader metoduyla çalıştırmasını söyledik.
            while(reader.Read())
            {
                Product product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UrunAdi = reader["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(reader["StokMiktari"]),
                    UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"])
                };

            }
            return products;
        }
    }
}
