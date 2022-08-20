using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDAL productDAL = new ProductDAL(); // Veritabanı işlemleri olduğu sınıfı tanımladık
        
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //dgvUrunler.DataSource = productDAL.GetAll(); // Form ön yüzdeki dgvUrunler nesnesine productDAL içindeki GetAll metodu ile ürünleri yüklettik
            dgvUrunler1.DataSource = productDAL.GetAllDataTable(); // data table ile yaptığımız veri çekme metodu
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product product = new Product(); // boş bir product nesnesi oluşturduk
            product.StokMiktari = Convert.ToInt32(txtStokMiktari1.Text);
            product.UrunAdi = txtUrunAdi1.Text;
            product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati1.Text);
            var islemSonucu = productDAL.Add(product); // Add metoduna product ı eklemesi için gönderdik

            if (islemSonucu > 0)
            {
                dgvUrunler1.DataSource = productDAL.GetAllDataTable(); // Data grid view de eklenen son kaydı da görebilmek için  bu kodu yazdık
                MessageBox.Show("Kayıt Başarılı");
            }
            else MessageBox.Show("Kayıt Başarısız");
        }
    }
}
