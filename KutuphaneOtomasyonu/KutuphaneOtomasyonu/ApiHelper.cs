using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace KutuphaneOtomasyonu
{
    public static class ApiHelper
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// 📌 Open Library API'den barkod numarasına göre kitap bilgisi çeker.
        /// </summary>
        public static async Task<(string kitapAdi, string yazarAdi, int sayfaSayisi)> KitapBilgisiGetir(string barkod)
        {
            if (string.IsNullOrWhiteSpace(barkod))
                return ("Bilinmiyor", "Bilinmiyor", 0); // ✅ Geçersiz girişleri ele al

            try
            {
                string apiUrl = $"https://openlibrary.org/api/books?bibkeys=ISBN:{barkod}&format=json&jscmd=data";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); // ✅ Hatalı yanıtları yakalar

                string jsonString = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(jsonString);

                string key = $"ISBN:{barkod}";

                // 📌 **Key kontrolü eklenerek null referans hatası engellendi**
                if (json.TryGetValue(key, out JToken? kitapBilgisi) && kitapBilgisi is JObject kitapObj)
                {
                    string kitapAdi = kitapObj["title"]?.ToString() ?? "Bilinmiyor";
                    string yazarAdi = "Bilinmiyor";
                    int sayfaSayisi = 0;

                    // 📌 **Yazar bilgisi varsa güvenli şekilde al**
                    if (kitapObj.TryGetValue("authors", out JToken? yazarlar) && yazarlar is JArray authorsArray && authorsArray.Count > 0)
                    {
                        yazarAdi = authorsArray[0]?["name"]?.ToString() ?? "Bilinmiyor";
                    }

                    // 📌 **Sayfa sayısı bilgisini çek**
                    if (kitapObj.TryGetValue("number_of_pages", out JToken? sayfa) && sayfa != null)
                    {
                        int.TryParse(sayfa.ToString(), out sayfaSayisi);
                    }

                    return (kitapAdi, yazarAdi, sayfaSayisi);
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"[HTTP Hatası] Kitap bilgisi çekerken hata oluştu: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Genel Hata] Kitap bilgisi çekerken hata oluştu: {ex.Message}");
            }

            return ("Bilinmiyor", "Bilinmiyor", 0);
        }
    }
}
