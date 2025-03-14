using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class FormIslem : Form
    {
        private int seciliKitapID;
        private bool yeniKitapEklemeModu = false;

        public FormIslem(int kitapID, bool yeniKitap = false)
        {
            InitializeComponent();
            yeniKitapEklemeModu = yeniKitap;

            chkManuelGiris.CheckedChanged += chkManuelGiris_CheckedChanged;

            if (!yeniKitapEklemeModu)
            {
                seciliKitapID = kitapID;
                KitapBilgileriniYukle();
                btnEkle.Visible = false;
            }
            else
            {
                btnGuncelle.Visible = false;
                btnSil.Visible = false;
            }

            cmbKategori.Items.AddRange(new string[] { "Roman", "Bilim", "Tarih", "Sanat", "Eğitim", "Biyografi", "Fantastik", "Diğer" });
            cmbKategori.SelectedIndex = 0;
            cmbDurum.Items.AddRange(new string[] { "Mevcut", "Ödünç Verildi", "Kayıp", "Bakımda" });
            cmbDurum.SelectedIndex = 0;

            chkManuelGiris.Checked = false; // Varsayılan: barkod modu
        }

        private void FormIslem_Load(object sender, EventArgs e)
        {
            if (!yeniKitapEklemeModu)
            {
                KitapBilgileriniYukle();
            }
        }

        private void KitapBilgileriniYukle()
        {
            using (var conn = Veritabani.BaglantiAc())
            {
                conn.Open();
                string sql = "SELECT * FROM Kitaplar WHERE id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", seciliKitapID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtKitapAdi.Text = reader["kitap_adi"].ToString();
                            txtYazarAdi.Text = reader["yazar_adi"].ToString();
                            txtSayfaSayisi.Text = reader["sayfa_sayisi"].ToString();
                            txtBarkodNumarasi.Text = reader["barkod_numarasi"].ToString();
                            cmbKategori.SelectedItem = reader["kategori"].ToString();
                            cmbDurum.SelectedItem = reader["durum"].ToString();
                        }
                    }
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKitapAdi.Text) || string.IsNullOrEmpty(txtYazarAdi.Text))
            {
                MessageBox.Show("Lütfen kitap bilgilerini eksiksiz girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = Veritabani.BaglantiAc())
            {
                conn.Open();
                string sql = "INSERT INTO Kitaplar (kitap_adi, yazar_adi, sayfa_sayisi, barkod_numarasi, kategori, durum) VALUES (@kitapAdi, @yazarAdi, @sayfaSayisi, @barkod, @kategori, @durum)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kitapAdi", txtKitapAdi.Text);
                    cmd.Parameters.AddWithValue("@yazarAdi", txtYazarAdi.Text);
                    cmd.Parameters.AddWithValue("@sayfaSayisi", Convert.ToInt32(txtSayfaSayisi.Text));
                    cmd.Parameters.AddWithValue("@barkod", txtBarkodNumarasi.Text);
                    cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedItem?.ToString() ?? "Diğer");
                    cmd.Parameters.AddWithValue("@durum", cmbDurum.SelectedItem?.ToString() ?? "Bilinmiyor");
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Kitap başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (var conn = Veritabani.BaglantiAc())
            {
                conn.Open();
                string sql = "UPDATE Kitaplar SET kitap_adi = @kitapAdi, yazar_adi = @yazarAdi, sayfa_sayisi = @sayfaSayisi, kategori = @kategori, durum = @durum WHERE id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kitapAdi", txtKitapAdi.Text);
                    cmd.Parameters.AddWithValue("@yazarAdi", txtYazarAdi.Text);
                    cmd.Parameters.AddWithValue("@sayfaSayisi", Convert.ToInt32(txtSayfaSayisi.Text));
                    cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedItem?.ToString() ?? "Diğer");
                    cmd.Parameters.AddWithValue("@durum", cmbDurum.SelectedItem?.ToString() ?? "Bilinmiyor");
                    cmd.Parameters.AddWithValue("@id", seciliKitapID);
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Kitap başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kitap güncellenemedi! Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kitabı silmek istediğinizden emin misiniz?", "Kitap Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var conn = Veritabani.BaglantiAc())
                {
                    conn.Open();
                    string sql = "DELETE FROM Kitaplar WHERE id = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", seciliKitapID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kitap başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private async void txtKitapNumarasi_TextChanged(object? sender, EventArgs e)
        {
            if (chkManuelGiris.Checked) return;

            string barkod = txtBarkodNumarasi.Text.Trim();
            if (!string.IsNullOrEmpty(barkod) && barkod.Length >= 10)
            {
                if (Veritabani.BarkodVarMi(barkod))
                {
                    MessageBox.Show("Bu barkod zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Üç öğeli tuple'ı deconstruct ediyoruz:
                var (kitapAdi, yazarAdi, sayfaSayisi) = await ApiHelper.KitapBilgisiGetir(barkod);
                if (kitapAdi != "Bilinmiyor" && yazarAdi != "Bilinmiyor")
                {
                    txtKitapAdi.Text = kitapAdi;
                    txtYazarAdi.Text = yazarAdi;
                    txtSayfaSayisi.Text = sayfaSayisi.ToString();
                    MessageBox.Show("Kitap bilgileri getirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kitap bilgisi bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private async void btnKitapBilgisiGetir_Click(object sender, EventArgs e)
        {
            string barkod = txtBarkodNumarasi.Text.Trim();
            if (!string.IsNullOrEmpty(barkod) && barkod.Length >= 10)
            {
                // Örneğin, txtKitapNumarasi_TextChanged içinde:
                var (kitapAdi, yazarAdi, sayfaSayisi) = await ApiHelper.KitapBilgisiGetir(barkod);
                if (kitapAdi != "Bilinmiyor" && yazarAdi != "Bilinmiyor")
                {
                    txtKitapAdi.Text = kitapAdi;
                    txtYazarAdi.Text = yazarAdi;
                    txtSayfaSayisi.Text = sayfaSayisi.ToString();
                    MessageBox.Show("Kitap bilgileri getirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kitap bilgisi bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Geçerli bir barkod numarası girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkManuelGiris_CheckedChanged(object? sender, EventArgs e)
        {
            bool manuelGiris = chkManuelGiris.Checked;
            txtKitapAdi.ReadOnly = !manuelGiris;
            txtYazarAdi.ReadOnly = !manuelGiris;
            txtBarkodNumarasi.ReadOnly = !manuelGiris;
            cmbKategori.Enabled = manuelGiris;
            cmbDurum.Enabled = manuelGiris;
            if (!manuelGiris)
            {
                txtKitapAdi.Clear();
                txtYazarAdi.Clear();
                txtBarkodNumarasi.Clear();
            }
        }

       
        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Uygulamayı kapatmak için
            Application.Exit();
        }

    }
}
