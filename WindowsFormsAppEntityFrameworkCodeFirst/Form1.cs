using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;
using WindowsFormsAppEntityFrameworkCodeFirst.Entities;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext(); //EF code first ü kullanabilmek için DatabaseContext sınıfımızdan bu şekilde bir nesne oluşturmalıyız
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler1.DataSource = context.Urunler.ToList(); // context nesnemiz üzerindeki ürünler isimli dbset üzerinden veritabanı içindeki kayıtları listeliyoruz
        }

        private void btnEkle1_Click(object sender, EventArgs e)
        {
            try
            {
                context.Urunler.Add(
                    new Urun
                    {
                        Adi = txtUrunAdi1.Text,
                        Fiyati = Convert.ToDecimal(txtUrunFiyati1.Text),
                        Stok = Convert.ToInt32(txtStokMiktari1.Text)
                    }
                    );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler1.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Başarılı");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

       
        
        private void dgvUrunler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
                var kayit = context.Urunler.Find(id);

                txtUrunAdi1.Text = kayit.Adi;
                txtStokMiktari1.Text = kayit.Stok.ToString();
                txtUrunFiyati1.Text = kayit.Fiyati.ToString();

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;


            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }
         private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
                var kayit = context.Urunler.Find(id);

                kayit.Adi = txtUrunAdi1.Text;
                kayit.Fiyati= Convert.ToDecimal(txtUrunFiyati1.Text);
                kayit.Stok= Convert.ToInt32(txtStokMiktari1.Text);

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler1.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Başarılı");
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
                int id = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
                var kayit = context.Urunler.Find(id);

                context.Urunler.Remove(kayit);



                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler1.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Silidi");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler1.DataSource = context.Urunler.Where(u=>u.Adi.Contains(txtAra.Text)).ToList();
        }
    }
}
