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
    public partial class MarkaYonetimi : Form
    {
        public MarkaYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();

        private void MarkaYonetimi_Load(object sender, EventArgs e)
        {
            dgvMarkalar.DataSource = context.Markalar.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarkaAdi.Text))
            {
                MessageBox.Show("Marka Adı Boş Geçilemez");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Açıklama Alanı Boş Geçilemez");
                return;
            }
                try

            {
                Marka marka = new Marka()
                {
                    Adi = txtMarkaAdi.Text,
                    Aciklama = txtAciklama.Text,
                };
                context.Markalar.Add(marka);
                context.SaveChanges();

                dgvMarkalar.DataSource = context.Markalar.ToList();
                MessageBox.Show("Kayıt Başarılı");

            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMarkaAdi.Text = dgvMarkalar.CurrentRow.Cells[1].Value.ToString(); // 0'da id var o yüzden 1 yazdık
                txtAciklama.Text = dgvMarkalar.CurrentRow.Cells[2].Value.ToString();

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
                int id = Convert.ToInt32(dgvMarkalar.CurrentRow.Cells[0].Value);
                Marka marka = context.Markalar.FirstOrDefault(k => k.Id == id); // FirstOrDefault metodu kendisine gönderilen soruya ait kaydı veritabanından bulur. 
                marka.Adi = txtMarkaAdi.Text;
                marka.Aciklama = txtAciklama.Text;

                context.SaveChanges();

                dgvMarkalar.DataSource = context.Markalar.ToList();

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
                int id = Convert.ToInt32(dgvMarkalar.CurrentRow.Cells[0].Value);
                Marka marka = context.Markalar.SingleOrDefault(k => k.Id == id); // SingleOrDefault metodu veritabanındaki 1 kaydı getirmek için kullanılır, eğer şarta uyan 1 den fazla kayıt bulursa hata verir.
                context.Markalar.Remove(marka);
                var islemSonucu = context.SaveChanges();

                if (islemSonucu > 0)
                {
                    dgvMarkalar.DataSource = context.Markalar.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}
