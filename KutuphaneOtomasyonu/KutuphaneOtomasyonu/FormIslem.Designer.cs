namespace KutuphaneOtomasyonu
{
    partial class FormIslem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtKitapAdi;
        private System.Windows.Forms.TextBox txtYazarAdi;
        private System.Windows.Forms.TextBox txtSayfaSayisi;
        private System.Windows.Forms.TextBox txtBarkodNumarasi;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.CheckBox chkManuelGiris;
        

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
            this.txtKitapAdi = new System.Windows.Forms.TextBox();
            this.txtYazarAdi = new System.Windows.Forms.TextBox();
            this.txtSayfaSayisi = new System.Windows.Forms.TextBox();
            this.txtBarkodNumarasi = new System.Windows.Forms.TextBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.chkManuelGiris = new System.Windows.Forms.CheckBox();

            this.SuspendLayout();
            // 
            // chkManuelGiris
            // 
            this.chkManuelGiris.AutoSize = true;
            this.chkManuelGiris.Location = new System.Drawing.Point(50, 20);
            this.chkManuelGiris.Name = "chkManuelGiris";
            this.chkManuelGiris.Size = new System.Drawing.Size(138, 24);
            this.chkManuelGiris.TabIndex = 0;
            this.chkManuelGiris.Text = "Manuel Giriş Yap";
            this.chkManuelGiris.UseVisualStyleBackColor = true;
            this.chkManuelGiris.CheckedChanged += new System.EventHandler(this.chkManuelGiris_CheckedChanged);
            // 
            // txtKitapAdi
            // 
            this.txtKitapAdi.Location = new System.Drawing.Point(50, 60);
            this.txtKitapAdi.Name = "txtKitapAdi";
            this.txtKitapAdi.Size = new System.Drawing.Size(300, 27);
            this.txtKitapAdi.TabIndex = 1;
            this.txtKitapAdi.PlaceholderText = "Kitap Adı";
            // 
            // txtYazarAdi
            // 
            this.txtYazarAdi.Location = new System.Drawing.Point(50, 100);
            this.txtYazarAdi.Name = "txtYazarAdi";
            this.txtYazarAdi.Size = new System.Drawing.Size(300, 27);
            this.txtYazarAdi.TabIndex = 2;
            this.txtYazarAdi.PlaceholderText = "Yazar Adı";
            // 
            // txtSayfaSayisi
            // 
            this.txtSayfaSayisi.Location = new System.Drawing.Point(50, 140);
            this.txtSayfaSayisi.Name = "txtSayfaSayisi";
            this.txtSayfaSayisi.Size = new System.Drawing.Size(300, 27);
            this.txtSayfaSayisi.TabIndex = 3;
            this.txtSayfaSayisi.PlaceholderText = "Sayfa Sayısı";
            // 
            // txtBarkodNumarasi
            // 
            this.txtBarkodNumarasi.Location = new System.Drawing.Point(50, 180);
            this.txtBarkodNumarasi.Name = "txtBarkodNumarasi";
            this.txtBarkodNumarasi.Size = new System.Drawing.Size(300, 27);
            this.txtBarkodNumarasi.TabIndex = 4;
            this.txtBarkodNumarasi.PlaceholderText = "Barkod Numarası";
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(50, 220);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(300, 28);
            this.cmbKategori.TabIndex = 5;
            // Varsayılan kategori seçenekleri
            this.cmbKategori.Items.AddRange(new object[] { "Roman", "Bilim", "Tarih", "Sanat", "Eğitim", "Biyografi", "Fantastik", "Diğer" });
            this.cmbKategori.SelectedIndex = 0;
            // 
            // cmbDurum
            // 
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Location = new System.Drawing.Point(50, 260);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(300, 28);
            this.cmbDurum.TabIndex = 6;
            // Varsayılan durum seçenekleri
            this.cmbDurum.Items.AddRange(new object[] { "Mevcut", "Ödünç Verildi", "Kayıp", "Bakımda" });
            this.cmbDurum.SelectedIndex = 0;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(50, 310);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 30);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Kitap Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(160, 310);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 30);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(270, 310);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 30);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FormIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.txtBarkodNumarasi);
            this.Controls.Add(this.txtSayfaSayisi);
            this.Controls.Add(this.txtYazarAdi);
            this.Controls.Add(this.txtKitapAdi);
            this.Controls.Add(this.chkManuelGiris);
            this.Name = "FormIslem";
            this.Text = "Kitap İşlemleri";
            this.Load += new System.EventHandler(this.FormIslem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
