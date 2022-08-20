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
            List<Product> urunListesi = new List<Product>(); // Geriye döndüreceğimiz boş bir List<Product> nesnesi oluşturduk.
            SqlCommand command = new SqlCommand("select * from Products", connection); // SqlCommand sql komutlarını çalıştırabilmemizi sağlayan ado net sınıfıdır. Tırnaklar içerisinie sql komutumuzu, sonraki parametrede de bu komutun çalıştıracağı connection nesnesini belirtiyoruz.
            SqlDataReader reader = command.ExecuteReader(); // SqlDataReader Sql veri okuyucu sınıfıdır, bu sınıfa üstteki command nesnesini ExecuteReader metoduyla çalıştırmasını söyledik.
            while(reader.Read()) // reader db de okuyacak kayıt bulduğu sürece 
            {
                Product product = new Product() //Döngü her döndüğünde içi boş yeni ürün oluşturuyoruz
                {
                    // Aşağıda veritabanından gelen verilerle ürün bilgilerini dolduruyoruz
                    Id = Convert.ToInt32(reader["Id"]),
                    UrunAdi = reader["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(reader["StokMiktari"]),
                    UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"])
                };
                urunListesi.Add(product); //içi doldurulan product nesnesini yukarıda oluşturduğumuz products
            }
            reader.Close(); //Veri okuyucuyu kapat // aşağıdakiler sondan başa doğru kapatılır
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat // en son iletişim kesiyoruz
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
            SqlCommand command = new SqlCommand("Insert into Products (UrunAdi, UrunFiyati, StokMiktari) values (@UrunAdi, @UrunFiyati, @Stok", connection); // Sql komutu olarak bu sefer insert komutu yazık // stokta olduğu gibi birebir yazmak zorunda değiliz
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati);
            command.Parameters.AddWithValue("@Stok", product.StokMiktari);
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat
            return islemSonucu; // metodumuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }
    }
}
