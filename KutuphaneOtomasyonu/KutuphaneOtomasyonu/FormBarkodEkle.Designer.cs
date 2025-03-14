namespace KutuphaneOtomasyonu
{
    partial class FormBarkodEkle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBarkodNumarasi;
        private System.Windows.Forms.Button btnBarkodSorgula;
        private System.Windows.Forms.TextBox txtKitapAdi;
        private System.Windows.Forms.TextBox txtYazarAdi;
        private System.Windows.Forms.TextBox txtSayfaSayisi;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.Button btnIptal;

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

        private void InitializeComponent()
        {
            txtBarkodNumarasi = new TextBox();
            btnBarkodSorgula = new Button();
            txtKitapAdi = new TextBox();
            txtYazarAdi = new TextBox();
            txtSayfaSayisi = new TextBox();
            cmbKategori = new ComboBox();
            cmbDurum = new ComboBox();
            btnKitapEkle = new Button();
            btnIptal = new Button();
            SuspendLayout();
            // 
            // txtBarkodNumarasi
            // 
            txtBarkodNumarasi.Location = new Point(30, 20);
            txtBarkodNumarasi.Name = "txtBarkodNumarasi";
            txtBarkodNumarasi.PlaceholderText = "Barkod Numarası";
            txtBarkodNumarasi.Size = new Size(200, 27);
            txtBarkodNumarasi.TabIndex = 0;
            // 
            // btnBarkodSorgula
            // 
            btnBarkodSorgula.Location = new Point(240, 20);
            btnBarkodSorgula.Name = "btnBarkodSorgula";
            btnBarkodSorgula.Size = new Size(150, 27);
            btnBarkodSorgula.TabIndex = 1;
            btnBarkodSorgula.Text = "Barkod ile Getir";
            btnBarkodSorgula.UseVisualStyleBackColor = true;
            btnBarkodSorgula.Click += btnBarkodSorgula_Click;
            // 
            // txtKitapAdi
            // 
            txtKitapAdi.Location = new Point(30, 60);
            txtKitapAdi.Name = "txtKitapAdi";
            txtKitapAdi.PlaceholderText = "Kitap Adı";
            txtKitapAdi.Size = new Size(360, 27);
            txtKitapAdi.TabIndex = 2;
            // 
            // txtYazarAdi
            // 
            txtYazarAdi.Location = new Point(30, 100);
            txtYazarAdi.Name = "txtYazarAdi";
            txtYazarAdi.PlaceholderText = "Yazar Adı";
            txtYazarAdi.Size = new Size(360, 27);
            txtYazarAdi.TabIndex = 3;
            // 
            // txtSayfaSayisi
            // 
            txtSayfaSayisi.Location = new Point(30, 140);
            txtSayfaSayisi.Name = "txtSayfaSayisi";
            txtSayfaSayisi.PlaceholderText = "Sayfa Sayısı";
            txtSayfaSayisi.Size = new Size(200, 27);
            txtSayfaSayisi.TabIndex = 4;
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Items.AddRange(new object[] { "Roman", "Bilim", "Tarih", "Sanat", "Eğitim", "Biyografi", "Fantastik", "Diğer" });
            cmbKategori.Location = new Point(30, 180);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(200, 28);
            cmbKategori.TabIndex = 5;
            // 
            // cmbDurum
            // 
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Items.AddRange(new object[] { "Mevcut", "Ödünç Verildi", "Kayıp", "Bakımda" });
            cmbDurum.Location = new Point(30, 220);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(200, 28);
            cmbDurum.TabIndex = 6;
            // 
            // btnKitapEkle
            // 
            btnKitapEkle.Location = new Point(30, 270);
            btnKitapEkle.Name = "btnKitapEkle";
            btnKitapEkle.Size = new Size(150, 30);
            btnKitapEkle.TabIndex = 7;
            btnKitapEkle.Text = "Kitabı Kaydet";
            btnKitapEkle.UseVisualStyleBackColor = true;
            btnKitapEkle.Click += btnKitapEkle_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(240, 270);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(150, 30);
            btnIptal.TabIndex = 8;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // FormBarkodEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 350);
            Controls.Add(btnIptal);
            Controls.Add(btnKitapEkle);
            Controls.Add(cmbDurum);
            Controls.Add(cmbKategori);
            Controls.Add(txtSayfaSayisi);
            Controls.Add(txtYazarAdi);
            Controls.Add(txtKitapAdi);
            Controls.Add(btnBarkodSorgula);
            Controls.Add(txtBarkodNumarasi);
            Name = "FormBarkodEkle";
            Text = "Barkod ile Kitap Ekle";
            this.Load += new System.EventHandler(this.FormBarkodEkle_Load);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
