using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkDbFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 
        /*
         * Entity Framework ORM(Object Relational Maping) araçlarından biridir. Veritabanı CRUD işlemlerini Sql sorgusu yazmadan Linq dili ile hazır metotları kullanarak proje geliştirebilmemizi sağlar.
         * entity Framework ile 4 farklı yöntem kullanarak proje geliştirebilirsiniz
         * 
         * Model First (Model oluşturup bu modele göre db oluşturarak) // çok tercih edilmez
         * Database First (Var olan veritabanını kullanma) // halen geçerli ve çok kullanılıyor
         * Code First (Önce Entity class larımızı oluşturup sonra veritabanını oluşturarak)
         * Code First (var olan veritabanını kullanarak Entity class arını oluşturarak)
         */
        // Entity Framework projelere dahili olarak ado.net gibi gelmez. Sonradan projeye sağ tıklayıp açıan menüden nuget package manager ı açıp burada browse menüsüne tıklayıtp arama çubuğundan entityFramework yazarak paketi bulup install diyerek açılan onay penceresinde  yüklememiz gerekir.

        UrunYonetimiAdoNetEntities context = new UrunYonetimiAdoNetEntities(); // Entity Framework ile veritabanı crud işlemlerini yapabimek için bu sınıftan bir nesne tanımlıyoruz.
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler1.DataSource = context.Products.ToList(); // EF ile context nesnesi üzerindeki Products dbset  ine ulaşıp veritabanındaaki ürünleri listeledik
        }

        private void btnEkle1_Click(object sender, EventArgs e)
        {
            try
            {
                context.Products.Add(new Products
                {
                    StokMiktari = Convert.ToInt32(txtStokMiktari1.Text),
                    UrunAdi = txtUrunAdi1.Text,
                    UrunFiyati = Convert.ToDecimal(txtUrunFiyati1.Text)
                });//  ykarıda dbset üzerine kaydı ekledik

                context.SaveChanges(); // burada context üzerinde yapılan bu değişikliği veritabanına kaydettik
                dgvUrunler1.DataSource = context.Products.ToList();
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void dgvUrunler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
            var kayit = context.Products.Find(secilenKayitId);  //  EF find metodu kendisine parametreyle gönderilen id ile eşleşen kaydı veitabanından getirir

            txtUrunAdi1.Text = kayit.UrunAdi;
            txtStokMiktari1.Text = kayit.StokMiktari.ToString();
            txtUrunFiyati1.Text = kayit.UrunFiyati.ToString();

            btnGuncelle.Enabled = true; // bu ve alttaki buttonlar form ik açıldığında pasifti soldakileri yazmamız sayesinde bir satır seçince aktif hale gelir 
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
                var kayit = context.Products.Find(secilenKayitId);
                kayit.UrunAdi = txtUrunAdi1.Text;
                kayit.UrunFiyati = Convert.ToDecimal(txtUrunFiyati1.Text);
                kayit.StokMiktari = Convert.ToInt32(txtStokMiktari1.Text);

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvUrunler1.DataSource = context.Products.ToList();
                    MessageBox.Show("Kayıt Güncellendi");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
                Products kayit = context.Products.Find(secilenKayitId);
                context.Products.Remove(kayit); // context üzerindeki Products tablosundn kayıt içindeki ürünü silinecek olarak işaretle

                var sonuc = context.SaveChanges(); // context üzerindeki değişiklikleri (Burada silme işlem
                                                   // e karşılık geliyor değişiklik) veritabanına işle
                                                   // EF de tracking denilen bir kavram var ve bu tracking EF Context üzerindeki değişiklikleri izler, takip eder, savechanges i çalıştırdığımızda db ye işler

                if (sonuc > 0) // context.SaveChanges() metodu geriye veritabanında etkilenen kayıt sayısını int olarak bize döndürür. sonuc değişkene bu değeri atadık ve if ile u değer 0 dan büyük mü diye kontrol ettik. Eğer silme başarılıysa sonuç değeri 1 olacaktır, başarısız olursa 0 olacaktır
                {
                    dgvUrunler1.DataSource = context.Products.ToList();
                    MessageBox.Show("Kayıt Silindi");
                }
                else MessageBox.Show("Kayıt Silinemedi");
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }
    }
       
}
