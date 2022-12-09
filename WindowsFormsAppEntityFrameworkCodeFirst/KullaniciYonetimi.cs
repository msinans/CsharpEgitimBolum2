using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;
using WindowsFormsAppEntityFrameworkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }

        DatabaseContext context = new DatabaseContext();
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            dgvKullanicilar.DataSource = context.Kullanicilar.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciTCNo.Text))
            {
                MessageBox.Show("TC No Boş Geçilemez");
                return;
            }
            try

            {
                Kullanici kullanici = new Kullanici()
                {
                    TCNo = Convert.ToInt32(txtKullaniciTCNo.Text),
                    Adi = txtKullaniciAdi.Text,
                    Soyadi = txtKullaniciSoyadi.Text,
                    Email = txtKullaniciEmail.Text,

                };
                context.Kullanicilar.Add(kullanici);
                context.SaveChanges();

                dgvKullanicilar.DataSource = context.Kullanicilar.ToList();
                MessageBox.Show("Kayıt Başarılı");

            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtKullaniciTCNo.Text = dgvKullanicilar.CurrentRow.Cells[1].Value.ToString(); // 0'da id var o yüzden 1 yazdık
                txtKullaniciAdi.Text = dgvKullanicilar.CurrentRow.Cells[2].Value.ToString();
                txtKullaniciSoyadi.Text = dgvKullanicilar.CurrentRow.Cells[3].Value.ToString();
                txtKullaniciEmail.Text = dgvKullanicilar.CurrentRow.Cells[4].Value.ToString();

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
                Kullanici kullanici = context.Kullanicilar.FirstOrDefault(k => k.Id == id); // FirstOrDefault metodu kendisine gönderilen soruya ait kaydı veritabanından bulur. 
                kullanici.TCNo = Convert.ToInt32(txtKullaniciTCNo.Text);
                kullanici.Adi = txtKullaniciAdi.Text;
                kullanici.Soyadi = txtKullaniciSoyadi.Text;
                kullanici.Email = txtKullaniciEmail.Text;

                context.SaveChanges();

                dgvKullanicilar.DataSource = context.Kullanicilar.ToList();

                MessageBox.Show("Güncelleme Başarılı"); // bunu if şartı ile yapmak daha garanti okur ancak bu da çalışır

            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
                Kullanici kullanici = context.Kullanicilar.SingleOrDefault(k => k.Id == id); // SingleOrDefault metodu veritabanındaki 1 kaydı getirmek için kullanılır, eğer şarta uyan 1 den fazla kayıt bulursa hata verir.
                context.Kullanicilar.Remove(kullanici);
                var islemSonucu = context.SaveChanges();

                if (islemSonucu > 0)
                {
                    dgvKullanicilar.DataSource = context.Kullanicilar.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dgvKullanicilar.DataSource = context.Kullanicilar.Where(k => k.Adi.Contains(txtAra.Text)).ToList();
        }
    }
}
