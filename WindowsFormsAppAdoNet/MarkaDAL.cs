using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WindowsFormsAppAdoNet
{
    public class MarkaDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet;integrated security= true");

        void ConnectionKontrol() // void =tek
        {
            if (connection.State == ConnectionState.Closed) //Eğer yukarıdaki veritabanı bağlantısı kapalıysa
            {
                connection.Open(); // bağlantıyı aç
            }
        }
        public DataTable GetAllDataTable()
        {
            ConnectionKontrol(); //bağlantıyı kontrol et
            DataTable dt = new DataTable(); // Boş bir datatable nesnesi oluştur
            SqlCommand command = new SqlCommand("select * from Markalar", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); //sql komut nesnesini kapat
            connection.Close(); // veritabanı bağlantısını kapat
            return dt; // metodun çağrıldığı yere dt(data tablosunu) gönder.
        }
        public int Add(Marka marka)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Markalar (MarkaAdi, StokMiktari) values (@MarkaAdi, @Stok)", connection); // Sql komutu olarak bu sefer insert komutu yazdık // stokta olduğu gibi birebir yazmak zorunda değiliz
            command.Parameters.AddWithValue("@MarkaAdi", marka.MarkaAdi);
            command.Parameters.AddWithValue("@Stok", marka.StokMiktari);

            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat
            return islemSonucu; // metodumuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }
    }
}
