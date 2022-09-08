using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkDbFirst
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }

        UrunYonetimiAdoNetEntities context = new UrunYonetimiAdoNetEntities();
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = context.Kategoriler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Kategoriler.Add(
                    new Kategoriler
                    {
                        KategoriAdi = txtKategoriAdi.Text,
                        Durum = cbDurum.Checked
                    });
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("kayıt Başarılı!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");

            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
            var kayit = context.Kategoriler.Find(secilenKayitId);  //  EF find metodu kendisine parametreyle gönderilen id ile eşleşen kaydı veitabanından getirir

            txtKategoriAdi.Text = kayit.KategoriAdi;
            cbDurum.Text = kayit.Durum.ToString();


            btnGuncelle.Enabled = true; // bu ve alttaki buttonlar form ik açıldığında pasifti soldakileri yazmamız sayesinde bir satır seçince aktif hale gelir 
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                var kayit = context.Kategoriler.Find(secilenKayitId);
                kayit.KategoriAdi = txtKategoriAdi.Text;
                kayit.Durum = Convert.ToBoolean(cbDurum.Checked);
               

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
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
                int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                Kategoriler kayit = context.Kategoriler.Find(secilenKayitId);
                context.Kategoriler.Remove(kayit); // context üzerindeki Products tablosundn kayıt içindeki ürünü silinecek olarak işaretle

                var sonuc = context.SaveChanges(); // context üzerindeki değişiklikleri (Burada silme işlem
                                                   // e karşılık geliyor değişiklik) veritabanına işle
                                                   // EF de tracking denilen bir kavram var ve bu tracking EF Context üzerindeki değişiklikleri izler, takip eder, savechanges i çalıştırdığımızda db ye işler

                if (sonuc > 0) // context.SaveChanges() metodu geriye veritabanında etkilenen kayıt sayısını int olarak bize döndürür. sonuc değişkene bu değeri atadık ve if ile u değer 0 dan büyük mü diye kontrol ettik. Eğer silme başarılıysa sonuç değeri 1 olacaktır, başarısız olursa 0 olacaktır
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
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
