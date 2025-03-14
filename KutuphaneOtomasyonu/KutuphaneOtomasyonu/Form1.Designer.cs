namespace KutuphaneOtomasyonu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnIslem;
        private System.Windows.Forms.Button btnYeniKitap;
        private System.Windows.Forms.Button btnBarkodKitapEkle;
        private System.Windows.Forms.ComboBox cmbFiltreKategori;
        private System.Windows.Forms.Button btnPdfKaydet;
        private System.Windows.Forms.Button btnCikis;

        /// <summary>
        /// Kullanılan tüm bileşenleri temizler.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnIslem = new System.Windows.Forms.Button();
            this.btnYeniKitap = new System.Windows.Forms.Button();
            this.btnBarkodKitapEkle = new System.Windows.Forms.Button();
            this.cmbFiltreKategori = new System.Windows.Forms.ComboBox();
            this.btnPdfKaydet = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // **DataGridView (Kitap Listesi)**
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(500, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // **Arama Kutusu**
            this.txtArama.Location = new System.Drawing.Point(550, 20);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(200, 27);
            this.txtArama.TabIndex = 1;

            // **Arama Butonu**
            this.btnAra.Location = new System.Drawing.Point(550, 60);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(100, 30);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);

            // **Seçili Kitap Üzerinde İşlem Yap Butonu**
            this.btnIslem.Location = new System.Drawing.Point(550, 100);
            this.btnIslem.Name = "btnIslem";
            this.btnIslem.Size = new System.Drawing.Size(200, 30);
            this.btnIslem.TabIndex = 3;
            this.btnIslem.Text = "Seçili Kitap Üzerinde İşlem Yap";
            this.btnIslem.UseVisualStyleBackColor = true;
            this.btnIslem.Click += new System.EventHandler(this.btnIslem_Click);

            // **Manuel Kitap Ekleme Butonu**
            this.btnYeniKitap.Location = new System.Drawing.Point(550, 140);
            this.btnYeniKitap.Name = "btnYeniKitap";
            this.btnYeniKitap.Size = new System.Drawing.Size(200, 30);
            this.btnYeniKitap.TabIndex = 4;
            this.btnYeniKitap.Text = "Manuel Kitap Ekle";
            this.btnYeniKitap.UseVisualStyleBackColor = true;
            this.btnYeniKitap.Click += new System.EventHandler(this.btnYeniKitap_Click);

            // **Barkod ile Kitap Ekleme Butonu**
            this.btnBarkodKitapEkle.Location = new System.Drawing.Point(550, 180);
            this.btnBarkodKitapEkle.Name = "btnBarkodKitapEkle";
            this.btnBarkodKitapEkle.Size = new System.Drawing.Size(200, 30);
            this.btnBarkodKitapEkle.TabIndex = 5;
            this.btnBarkodKitapEkle.Text = "Barkod ile Kitap Ekle";
            this.btnBarkodKitapEkle.UseVisualStyleBackColor = true;
            this.btnBarkodKitapEkle.Click += new System.EventHandler(this.btnBarkodKitapEkle_Click);

            // **Kategori Filtreleme Combobox**
            this.cmbFiltreKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreKategori.Location = new System.Drawing.Point(550, 220);
            this.cmbFiltreKategori.Name = "cmbFiltreKategori";
            this.cmbFiltreKategori.Size = new System.Drawing.Size(200, 28);
            this.cmbFiltreKategori.TabIndex = 6;
            this.cmbFiltreKategori.SelectedIndexChanged += new System.EventHandler(this.cmbFiltreKategori_SelectedIndexChanged);

            // **Kitapları PDF Olarak Kaydet Butonu**
            // **Kitapları PDF Olarak Kaydet Butonu**
            btnPdfKaydet.Location = new System.Drawing.Point(550, 260);
            btnPdfKaydet.Name = "btnPdfKaydet";
            btnPdfKaydet.Size = new System.Drawing.Size(200, 30);
            btnPdfKaydet.TabIndex = 7;
            btnPdfKaydet.Text = "Kitapları PDF Olarak Kaydet";
            btnPdfKaydet.UseVisualStyleBackColor = true;
            btnPdfKaydet.Click += new System.EventHandler(this.btnPdfKaydet_Click);


            // **Çıkış Butonu**
            this.btnCikis.Location = new System.Drawing.Point(550, 300);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(200, 30);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);

            // **Form1**
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnPdfKaydet);
            this.Controls.Add(this.cmbFiltreKategori);
            this.Controls.Add(this.btnBarkodKitapEkle);
            this.Controls.Add(this.btnYeniKitap);
            this.Controls.Add(this.btnIslem);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Kütüphane Otomasyonu";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
