namespace WindowsFormsAppAdoNet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUrunler1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrunAdi1 = new System.Windows.Forms.TextBox();
            this.txtUrunFiyati1 = new System.Windows.Forms.TextBox();
            this.txtStokMiktari1 = new System.Windows.Forms.TextBox();
            this.btnEkle1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUrunler1
            // 
            this.dgvUrunler1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler1.Location = new System.Drawing.Point(4, 12);
            this.dgvUrunler1.Name = "dgvUrunler1";
            this.dgvUrunler1.Size = new System.Drawing.Size(325, 313);
            this.dgvUrunler1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(47, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ürün Adı :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEkle1);
            this.groupBox2.Controls.Add(this.txtStokMiktari1);
            this.groupBox2.Controls.Add(this.txtUrunFiyati1);
            this.groupBox2.Controls.Add(this.txtUrunAdi1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(348, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürün Bilgileri";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ürün Fiyatı :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Stok Miktarı :";
            // 
            // txtUrunAdi1
            // 
            this.txtUrunAdi1.Location = new System.Drawing.Point(132, 29);
            this.txtUrunAdi1.Name = "txtUrunAdi1";
            this.txtUrunAdi1.Size = new System.Drawing.Size(100, 20);
            this.txtUrunAdi1.TabIndex = 3;
            // 
            // txtUrunFiyati1
            // 
            this.txtUrunFiyati1.Location = new System.Drawing.Point(132, 55);
            this.txtUrunFiyati1.Name = "txtUrunFiyati1";
            this.txtUrunFiyati1.Size = new System.Drawing.Size(100, 20);
            this.txtUrunFiyati1.TabIndex = 3;
            // 
            // txtStokMiktari1
            // 
            this.txtStokMiktari1.Location = new System.Drawing.Point(132, 81);
            this.txtStokMiktari1.Name = "txtStokMiktari1";
            this.txtStokMiktari1.Size = new System.Drawing.Size(100, 20);
            this.txtStokMiktari1.TabIndex = 3;
            // 
            // btnEkle1
            // 
            this.btnEkle1.Location = new System.Drawing.Point(146, 117);
            this.btnEkle1.Name = "btnEkle1";
            this.btnEkle1.Size = new System.Drawing.Size(75, 23);
            this.btnEkle1.TabIndex = 4;
            this.btnEkle1.Text = "Ekle";
            this.btnEkle1.UseVisualStyleBackColor = true;
            this.btnEkle1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(616, 391);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvUrunler1);
            this.Name = "Form1";
            this.Text = "ÜrünListesi1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStokMiktari;
        private System.Windows.Forms.TextBox txtUrunFiyati;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dgvUrunler1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEkle1;
        private System.Windows.Forms.TextBox txtStokMiktari1;
        private System.Windows.Forms.TextBox txtUrunFiyati1;
        private System.Windows.Forms.TextBox txtUrunAdi1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

