using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace KutuphaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Veritabani.VeritabaniOlustur();
            KategorileriDoldur();
            KitaplariListele();
        }

        private void KategorileriDoldur()
        {
            cmbFiltreKategori.Items.Clear();
            cmbFiltreKategori.Items.Add("Tüm Kategoriler");
            cmbFiltreKategori.Items.AddRange(new string[]
            {
                "Roman", "Bilim", "Tarih", "Sanat", "Eğitim",
                "Biyografi", "Fantastik", "Polisiye", "Çocuk", "Diğer"
            });

            cmbFiltreKategori.SelectedIndex = 0;
        }

        public void KitaplariListele(string? kategori = "Tüm Kategoriler")
        {
            try
            {
                using (var conn = Veritabani.BaglantiAc())
                {
                    conn.Open();
                    string sql = "SELECT id, kitap_adi, yazar_adi, sayfa_sayisi, barkod_numarasi, kategori, durum FROM Kitaplar";

                    if (!string.IsNullOrEmpty(kategori) && kategori != "Tüm Kategoriler")
                    {
                        sql += " WHERE kategori = @kategori";
                    }

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(kategori) && kategori != "Tüm Kategoriler")
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@kategori", kategori);
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitapları listelerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFiltreKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltreKategori.SelectedItem != null)
            {
                KitaplariListele(cmbFiltreKategori.SelectedItem.ToString());
            }
        }

        private void btnYeniKitap_Click(object sender, EventArgs e)
        {
            FormIslem formIslem = new FormIslem(0, true);
            formIslem.ShowDialog();
            KitaplariListele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi = txtArama.Text.Trim();

            if (!string.IsNullOrEmpty(aramaKelimesi))
            {
                KitaplariAra(aramaKelimesi);
            }
            else
            {
                KitaplariListele();
            }
        }

        private void KitaplariAra(string aramaKelimesi)
        {
            try
            {
                using (var conn = Veritabani.BaglantiAc())
                {
                    conn.Open();
                    string sql = "SELECT id, kitap_adi, yazar_adi, sayfa_sayisi, barkod_numarasi, kategori, durum FROM Kitaplar " +
                                "WHERE kitap_adi LIKE @arama OR yazar_adi LIKE @arama OR barkod_numarasi LIKE @arama OR kategori LIKE @arama";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@arama", "%" + aramaKelimesi + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap arama sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (selectedRow.Cells["kitap_adi"].Value != null)
                {
                    string kitapAdi = selectedRow.Cells["kitap_adi"].Value?.ToString() ?? "Bilinmiyor";
                    string yazarAdi = selectedRow.Cells["yazar_adi"].Value?.ToString() ?? "Bilinmiyor";
                    string sayfaSayisi = selectedRow.Cells["sayfa_sayisi"].Value?.ToString() ?? "Bilinmiyor";
                    string barkodNumarasi = selectedRow.Cells["barkod_numarasi"].Value?.ToString() ?? "Bilinmiyor";
                    string kategori = selectedRow.Cells["kategori"].Value?.ToString() ?? "Bilinmiyor";
                    string durum = selectedRow.Cells["durum"].Value?.ToString() ?? "Bilinmiyor";

                    MessageBox.Show($"📖 **Seçili Kitap:**\n\n" +
                                    $"📌 Kitap Adı: {kitapAdi}\n" +
                                    $"📌 Yazar: {yazarAdi}\n" +
                                    $"📌 Sayfa Sayısı: {sayfaSayisi}\n" +
                                    $"📌 Barkod Numarası: {barkodNumarasi}\n" +
                                    $"📌 Kategori: {kategori}\n" +
                                    $"📌 Durum: {durum}",
                                    "Kitap Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnIslem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kitapID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                FormIslem formIslem = new FormIslem(kitapID, false);
                formIslem.ShowDialog();
                KitaplariListele();
            }
            else
            {
                MessageBox.Show("Lütfen işlem yapmak için bir kitap seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBarkodKitapEkle_Click(object sender, EventArgs e)
        {
            FormBarkodEkle formBarkodEkle = new FormBarkodEkle();
            formBarkodEkle.ShowDialog();
            KitaplariListele();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uygulamadan çıkmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnPdfKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Dosyaları|*.pdf",
                Title = "PDF olarak kaydet",
                FileName = "Kutuphane_Kayitlari.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        PdfWriter writer = new PdfWriter(stream);
                        PdfDocument pdf = new PdfDocument(writer);
                        Document document = new Document(pdf);

                        PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                        document.Add(new Paragraph("Kütüphane Kayıtları")
                            .SetFont(boldFont)
                            .SetFontSize(18)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        document.Add(new Paragraph("\n"));

                        // DataGridView'deki verileri tabloya ekleme (örnek kod, sütun adlarına göre düzenleyin)
                        Table table = new Table(new float[] { 3, 4, 3, 3, 3, 3 }).SetWidth(iText.Layout.Properties.UnitValue.CreatePercentValue(100));

                        // Tablo başlıkları
                        string[] basliklar = { "Kitap Adı", "Yazar Adı", "Sayfa Sayısı", "Barkod", "Kategori", "Durum" };
                        foreach (string baslik in basliklar)
                        {
                            table.AddHeaderCell(new Cell().Add(new Paragraph(baslik).SetFont(boldFont)));
                        }

                        // DataGridView satırlarından verileri alarak tabloya ekle
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                table.AddCell(new Cell().Add(new Paragraph(row.Cells["kitap_adi"].Value?.ToString() ?? "")));
                                table.AddCell(new Cell().Add(new Paragraph(row.Cells["yazar_adi"].Value?.ToString() ?? "")));
                                table.AddCell(new Cell().Add(new Paragraph(row.Cells["sayfa_sayisi"].Value?.ToString() ?? "")));
                                table.AddCell(new Cell().Add(new Paragraph(row.Cells["barkod_numarasi"].Value?.ToString() ?? "")));
                                table.AddCell(new Cell().Add(new Paragraph(row.Cells["kategori"].Value?.ToString() ?? "")));
                                table.AddCell(new Cell().Add(new Paragraph(row.Cells["durum"].Value?.ToString() ?? "")));
                            }
                        }

                        document.Add(table);
                        document.Close();
                    }

                    MessageBox.Show("PDF başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF kaydedilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}