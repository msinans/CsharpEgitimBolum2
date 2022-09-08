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


    }
}
