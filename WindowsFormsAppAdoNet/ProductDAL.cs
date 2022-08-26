using System;
using System.Collections.Generic;

using System.Data; //Veritabanı işlemi için gerekli
using System.Data.SqlClient; //AdoNet kütüphaneleri
using System.Data.Common;

namespace WindowsFormsAppAdoNet
{
    public class ProductDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet;integrated security= true"); //Veritabanına bağlanmak için kullandığımız ado net sınıfıdır. Parametre olarak kendisine verilen bilgilerdeki veritabanına bağlanır.
        void ConnectionKontrol() // void =tek
        {
            if (connection.State == ConnectionState.Closed) //Eğer yukarıdaki veritabanı bağlantısı kapalıysa
            {
                connection.Open(); // bağlantıyı aç
            }
        }
        public List<Product> GetAll() // Bu metodun geri dönüş değeri List<Product> yani ürün listesidir.
        {
            ConnectionKontrol(); // Metot çalıştığı anda bağlantıyı kontrol et
            List<Product> urunListesi = new List<Product>(); // Geriye döndüreceğimiz boş bir List<Product> nesnesi oluşturduk.
            SqlCommand command = new SqlCommand("select * from Products", connection); // SqlCommand sql komutlarını çalıştırabilmemizi sağlayan ado net sınıfıdır. Tırnaklar içerisinie sql komutumuzu, sonraki parametrede de bu komutun çalıştıracağı connection nesnesini belirtiyoruz.
            SqlDataReader reader = command.ExecuteReader(); // SqlDataReader Sql veri okuyucu sınıfıdır, bu sınıfa üstteki command nesnesini ExecuteReader metoduyla çalıştırmasını söyledik.
            while(reader.Read()) // reader db de okuyacak kayıt bulduğu sürece 
            {
                Product product = new Product() //Döngü her döndüğünde içi boş yeni ürün oluşturuyoruz
                {
                    // Aşağıda veritabanından gelen verilerle ürün bilgilerini dolduruyoruz
                    Id = Convert.ToInt32(reader["Id"]),
                    UrunAdi1 = reader["UrunAdi"].ToString(),
                    StokMiktari1 = Convert.ToInt32(reader["StokMiktari"]),
                    UrunFiyati1 = Convert.ToDecimal(reader["UrunFiyati"])
                };
                urunListesi.Add(product); //içi doldurulan product nesnesini yukarıda oluşturduğumuz products listesine ekliyoruz
            }
            reader.Close(); //Veri okuyucuyu kapat // yukarıda en son açtığımızı önce kapatıyoruz
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat // en son iletişimi kesiyoruz
            return urunListesi;
        }
        public DataTable GetAllDataTable()
        {
            ConnectionKontrol(); //bağlantıyı kontrol et
            DataTable dt = new DataTable(); // Boş bir datatable nesnesi oluştur
            SqlCommand command = new SqlCommand("select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); //sql komut nesnesini kapat
            connection.Close(); // veritabanı bağlantısını kapat
            return dt; // metodun çağrıldığı yere dt(data tablosunu) gönder.
        }
        public int Add(Product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Products (UrunAdi, UrunFiyati, StokMiktari) values (@UrunAdi, @UrunFiyati, @Stok)", connection); // Sql komutu olarak bu sefer insert komutu yazdık // stokta olduğu gibi birebir yazmak zorunda değiliz
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi1);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati1);
            command.Parameters.AddWithValue("@Stok", product.StokMiktari1);
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat
            return islemSonucu; // metodumuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }
        public Product GetProduct(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("select * from Products where Id = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product = new Product();

            while(reader.Read())
            {
                product.Id = Convert.ToInt32(reader["Id"]);
                product.UrunAdi1 = reader["UrunAdi"].ToString();
                product.StokMiktari1 = Convert.ToInt32(reader["StokMiktari"]);
                product.UrunFiyati1 = Convert.ToDecimal(reader["UrunFiyati"]);
            }
            reader.Close(); 
            command.Dispose(); 
            connection.Close(); 
           
            return product;
          
        }
        public int Update(Product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Products set UrunAdi =@UrunAdi , UrunFiyati = @UrunFiyati, StokMiktari = @Stok where Id = @UrunId ", connection); // Sql komutu olarak bu sefer insert komutu yazdık // stokta olduğu gibi birebir yazmak zorunda değiliz. 
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi1);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati1);
            command.Parameters.AddWithValue("@Stok", product.StokMiktari1);
            command.Parameters.AddWithValue("@UrunId", product.Id);
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat
            return islemSonucu; // metodumuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }
        public int Delete(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Delete from Products where Id = @UrunId", connection);
            command.Parameters.AddWithValue("@UrunId", id);
            int islemSonucu = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return islemSonucu;






        }
    }
}
