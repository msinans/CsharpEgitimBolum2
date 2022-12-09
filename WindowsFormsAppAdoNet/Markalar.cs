using System;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class Markalar : Form
    {
        public Markalar()
        {
            InitializeComponent();
        }

        MarkaDAL markaDAL = new MarkaDAL();
        private void Markalar_Load(object sender, EventArgs e)
        {
            dgvMarkalar.DataSource = markaDAL.GetAllDataTable();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int sonuc = markaDAL.Add(new Marka
                {
                    MarkaAdi = txtMarkaAdi.Text,
                    StokMiktari = Convert.ToInt32(txtStokMiktari.Text)

                });
                if (sonuc > 0)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    dgvMarkalar.DataSource = markaDAL.GetAllDataTable();
                }
                else MessageBox.Show("Kayıt Başarısız");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu");
            }
        }
    }
}
