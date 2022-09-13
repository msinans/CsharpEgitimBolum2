using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                txtKullaniciSoyadi.Text= dgvKullanicilar.CurrentRow.Cells[3].Value.ToString();
                txtKullaniciEmail.Text = dgvKullanicilar.CurrentRow.Cells[4].Value.ToString();

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }
    }
}
