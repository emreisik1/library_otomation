using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu
{
    public partial class FormBarkodEkle : Form
    {
        public FormBarkodEkle()
        {
            InitializeComponent();
        }

        private async void btnBarkodSorgula_Click(object sender, EventArgs e)
        {
            string barkod = txtBarkodNumarasi.Text.Trim();

            if (string.IsNullOrEmpty(barkod))
            {
                MessageBox.Show("Lütfen bir barkod numarası girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Veritabani.BarkodVarMi(barkod))
            {
                MessageBox.Show("Bu barkod zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 📌 **API'den kitap bilgilerini çek**
            var (kitapAdi, yazarAdi, sayfaSayisi) = await ApiHelper.KitapBilgisiGetir(barkod);

            // 📌 **Bilgileri form alanlarına yaz**
            txtKitapAdi.Text = kitapAdi;
            txtYazarAdi.Text = yazarAdi;
            txtSayfaSayisi.Text = sayfaSayisi > 0 ? sayfaSayisi.ToString() : "Bilinmiyor";

            if (kitapAdi == "Bilinmiyor")
            {
                MessageBox.Show("Kitap bilgisi bulunamadı! Manuel giriş yapabilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Kitap bilgileri başarıyla getirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKitapAdi.Text) || string.IsNullOrEmpty(txtYazarAdi.Text) || string.IsNullOrEmpty(txtSayfaSayisi.Text))
            {
                MessageBox.Show("Lütfen tüm kitap bilgilerini girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string kitapAdi = txtKitapAdi.Text.Trim();
            string yazarAdi = txtYazarAdi.Text.Trim();
            string barkodNumarasi = txtBarkodNumarasi.Text.Trim();
            string kategori = cmbKategori.SelectedItem?.ToString() ?? "Diğer";
            string durum = cmbDurum.SelectedItem?.ToString() ?? "Mevcut";

            if (!int.TryParse(txtSayfaSayisi.Text, out int sayfaSayisi))
            {
                MessageBox.Show("Sayfa sayısı geçerli bir sayı olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 📌 **Kitabı veritabanına ekle**
            bool eklendi = Veritabani.KitapEkle(kitapAdi, yazarAdi, sayfaSayisi, barkodNumarasi, kategori, durum);

            if (eklendi)
            {
                MessageBox.Show("Kitap başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kitap eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormBarkodEkle_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemleri buraya ekleyebilirsiniz.
            // Örneğin: Başlangıç ayarlarını yapmak için.
        }

    }
}
