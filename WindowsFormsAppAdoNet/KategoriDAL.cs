﻿using System;
using System.Collections.Generic;
using System.Data;          // Veritabanı ilemleriiçin gerekli
using System.Data.SqlClient; // Adonet kütüphaneleri
using System.Security;

namespace WindowsFormsAppAdoNet
{
    public class KategoriDAL
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
            SqlCommand command = new SqlCommand("select * from Kategoriler", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); //sql komut nesnesini kapat
            connection.Close(); // veritabanı bağlantısını kapat
            return dt; // metodun çağrıldığı yere dt(data tablosunu) gönder.
        }
        public int Add(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Kategoriler (KategoriAdi, Durum) values (@KategoriAdi, @Durum)", connection); // Sql komutu olarak bu sefer insert komutu yazdık // stokta olduğu gibi birebir yazmak zorunda değiliz
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            //command.Parameters.AddWithValue("@Stok", product.StokMiktari1);
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat
            return islemSonucu; // metodumuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }

        public Kategori Get(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("select * from Kategoriler where Id = " + id, connection); 
            SqlDataReader reader = command.ExecuteReader();
            Kategori kategori = new Kategori();

            while (reader.Read())
            {
                kategori.Id = Convert.ToInt32(reader["Id"]);
                kategori.KategoriAdi = reader["KategoroAdi"].ToString();
                kategori.Durum = Convert.ToBoolean(reader["Durum"]);
            }
            
            reader.Close(); //Veri okucuyu kapat
            command.Dispose(); // sql komut nesnesini kapat 
            connection.Close(); //veritabanı bağlantısını kapat

            return kategori; // metodumuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }

        public int Update(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Kategoriler set KategoriAdi = @KategoriAdi, Durum = @Durum where Id = @id", connection);
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            command.Parameters.AddWithValue("@id", kategori.Id);

            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye vetabanında etkilenen kayıt sayısını döner
            command.Dispose(); // Sql komut nesnesini kapat
            connection.Close(); // veritabanı bağlantısını kapat
            return islemSonucu; // metodumuz geriye int döndüğü için islemSonucu değişkeni geri dönüyoruz

        }
        public int Delete(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Delete from Kategoriler where Id = @Uid", connection);
            command.Parameters.AddWithValue("@id", id);
            int islemSonucu = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return islemSonucu;
        }

    }
}
