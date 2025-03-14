using System;
using System.Data.SQLite;
using System.IO;

namespace KutuphaneOtomasyonu
{
    public static class Veritabani
    {
        private static readonly string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kutuphane.db");
        private static readonly string connectionString = $"Data Source={dbPath};Version=3;";

        public static SQLiteConnection BaglantiAc()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void VeritabaniOlustur()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = BaglantiAc())
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Kitaplar (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        kitap_adi TEXT NOT NULL,
                        yazar_adi TEXT NOT NULL,
                        sayfa_sayisi INTEGER NOT NULL,
                        barkod_numarasi TEXT UNIQUE NOT NULL,
                        kategori TEXT NOT NULL,
                        durum TEXT NOT NULL
                    )";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool KitapEkle(string kitapAdi, string yazarAdi, int sayfaSayisi, string barkod, string kategori, string durum)
        {
            using (var conn = BaglantiAc())
            {
                conn.Open();
                string sql = "INSERT INTO Kitaplar (kitap_adi, yazar_adi, sayfa_sayisi, barkod_numarasi, kategori, durum) " +
                             "VALUES (@kitapAdi, @yazarAdi, @sayfaSayisi, @barkod, @kategori, @durum)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kitapAdi", kitapAdi);
                    cmd.Parameters.AddWithValue("@yazarAdi", yazarAdi);
                    cmd.Parameters.AddWithValue("@sayfaSayisi", sayfaSayisi);
                    cmd.Parameters.AddWithValue("@barkod", barkod);
                    cmd.Parameters.AddWithValue("@kategori", kategori);
                    cmd.Parameters.AddWithValue("@durum", durum);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static void IDleriYenidenSirala()
        {
            using (var conn = BaglantiAc())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    // 1. Geçici yeni tablo oluşturun
                    string createTable = @"
                CREATE TABLE IF NOT EXISTS Kitaplar_New (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    kitap_adi TEXT NOT NULL,
                    yazar_adi TEXT NOT NULL,
                    sayfa_sayisi INTEGER NOT NULL,
                    barkod_numarasi TEXT UNIQUE NOT NULL,
                    kategori TEXT NOT NULL,
                    durum TEXT NOT NULL
                );";
                    using (var cmd = new SQLiteCommand(createTable, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Eski tablodan verileri, ID sıralı olarak yeni tabloya kopyalayın
                    string insertData = @"
                INSERT INTO Kitaplar_New (kitap_adi, yazar_adi, sayfa_sayisi, barkod_numarasi, kategori, durum)
                SELECT kitap_adi, yazar_adi, sayfa_sayisi, barkod_numarasi, kategori, durum 
                FROM Kitaplar
                ORDER BY id;";
                    using (var cmd = new SQLiteCommand(insertData, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Eski tabloyu silin
                    string dropTable = "DROP TABLE Kitaplar;";
                    using (var cmd = new SQLiteCommand(dropTable, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Yeni tablonun adını eski tablo adıyla değiştirin
                    string renameTable = "ALTER TABLE Kitaplar_New RENAME TO Kitaplar;";
                    using (var cmd = new SQLiteCommand(renameTable, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 5. sqlite_sequence tablosunu güncelleyin (varsa)
                    string resetSequence = "UPDATE sqlite_sequence SET seq = (SELECT MAX(id) FROM Kitaplar) WHERE name='Kitaplar';";
                    using (var cmd = new SQLiteCommand(resetSequence, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }


        public static bool KitabiSil(string barkod)
        {
            using (var conn = BaglantiAc())
            {
                conn.Open();
                string sql = "DELETE FROM Kitaplar WHERE barkod_numarasi = @barkod";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@barkod", barkod);
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
        }

        public static bool KitapGuncelle(string barkod, string yeniAdi, string yeniYazar, int sayfaSayisi, string yeniKategori, string yeniDurum)
        {
            using (var conn = BaglantiAc())
            {
                conn.Open();
                string sql = @"
            UPDATE Kitaplar 
            SET kitap_adi = @kitapAdi, 
                yazar_adi = @yazarAdi, 
                sayfa_sayisi = @sayfaSayisi, 
                kategori = @kategori, 
                durum = @durum 
            WHERE barkod_numarasi = @barkod";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kitapAdi", yeniAdi);
                    cmd.Parameters.AddWithValue("@yazarAdi", yeniYazar);
                    cmd.Parameters.AddWithValue("@sayfaSayisi", sayfaSayisi);
                    cmd.Parameters.AddWithValue("@kategori", yeniKategori);
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@barkod", barkod);
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
        }


        public static bool BarkodVarMi(string barkodNumarasi)
        {
            using (var conn = BaglantiAc())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Kitaplar WHERE barkod_numarasi = @barkod";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@barkod", barkodNumarasi);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
