using System;
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
            try
            {
                Product product = new Product(); // boş bir product nesnesi oluşturduk
                product.StokMiktari1 = Convert.ToInt32(txtStokMiktari1.Text);
                product.UrunAdi1 = txtUrunAdi1.Text;
                product.UrunFiyati1 = Convert.ToDecimal(txtUrunFiyati1.Text);
                var islemSonucu = productDAL.Add(product); // Add metoduna product ı eklemesi için gönderdik

                if (islemSonucu > 0)
                {
                    dgvUrunler1.DataSource = productDAL.GetAllDataTable(); // Data grid view de eklenen son kaydı da görebilmek için  bu kodu yazdık
                    MessageBox.Show("Kayıt Başarılı");
                }
                else MessageBox.Show("Kayıt Başarısız");
            }
            catch (Exception hata)
            {

                //MessageBox.Show("Hata Oluştu!\nGeçersiz Değer Girdiniz");
                MessageBox.Show(hata.Message);
            }

        }
        // Ekleme işleminden sonraki işlemimiz, griedview den kayıt seçip seçilen kaydın bilgilerini tetboxlara doldurmak. Bunun için griedview ın events (olaylar) kısmında cell click olayını etkinleştirmemiz lazım.   Gried e sağ tık yapıp  properties e tıklatp açılan pencereden şimşek ikonuna tıklayıp oradan cellclick kutucuğuna mouse ile çift tıklayarak bu olayı aktifleştiriyoruz.
        private void dgvUrunler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtStokMiktari1.Text = dgvUrunler1.CurrentRow.Cells[3].Value.ToString();
            //txtUrunAdi1.Text = dgvUrunler1.CurrentRow.Cells[1].Value.ToString();
            //txtUrunFiyati1.Text = dgvUrunler1.CurrentRow.Cells[2].Value.ToString();
            // yukarıdaki üç satır verileri ancak listeden tıklandığında gösterir,  veritabanından çekmez

            string id = dgvUrunler1.CurrentRow.Cells[0].Value.ToString(); // seçili satırda ilk sütündaki id değerini elde ettik

            Product product = productDAL.GetProduct(id); //  boş bir product nesnesi oluşturup productDAL sınıfımızdaki GetProduct metodunda üstteki id dğerini göndererek bu id ye ait kaydı veritabanından çekmesini sağadık

            // veritabanından gelen product nesnesindeki verileri aşağıda textboxlara doldurduk
            txtStokMiktari1.Text = product.StokMiktari1.ToString();
            txtUrunAdi1.Text = product.UrunAdi1.ToString();
            txtUrunFiyati1.Text = product.UrunFiyati1.ToString();
            btnGuncelle.Enabled = true; // listeden katıt seçildiğinde butonu aktif et
            btnSil.Enabled = true; // sil butonunu aktif et

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {

                Product product = new Product(); // boş bir product nesnesi oluşturduk
                product.StokMiktari1 = Convert.ToInt32(txtStokMiktari1.Text);
                product.UrunAdi1 = txtUrunAdi1.Text;
                product.UrunFiyati1 = Convert.ToDecimal(txtUrunFiyati1.Text);
                product.Id = Convert.ToInt32(dgvUrunler1.CurrentRow.Cells[0].Value);
                var islemSonucu = productDAL.Update(product); // Add metoduna product ı eklemesi için gönderdik

                if (islemSonucu > 0)
                {
                    dgvUrunler1.DataSource = productDAL.GetAllDataTable(); // Data grid view de eklenen son kaydı da görebilmek için  bu kodu yazdık
                    MessageBox.Show("Kayıt Başarılı");
                }
                else MessageBox.Show("Kayıt Başarısız");
            }
            catch (Exception hata)
            {

                //MessageBox.Show("Hata Oluştu!\nGeçersiz Değer Girdiniz!");
                MessageBox.Show(hata.Message);
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var islemSonucu = productDAL.Delete(dgvUrunler1.CurrentRow.Cells[0].Value.ToString());
                if (islemSonucu > 0)
                {
                    dgvUrunler1.DataSource = productDAL.GetAllDataTable();
                    MessageBox.Show("Silme Başarılı");
                }
                else MessageBox.Show("Silme Başarısız");
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }
    }
}
