﻿using Newtonsoft.Json;
using System.Text;

class Program
{
    private static async Task Main(string[] args)
    {
        Console.Write("Lütfen çevirmek istediğiniz cümleyi giriniz: ");
        string inputText = Console.ReadLine();

        string apiKey = "";

        string translatedText = await TranslateTextToEnglish(inputText, apiKey); // Çeviri yap

        if (!string.IsNullOrEmpty(translatedText))
        {
            Console.WriteLine();
            Console.Write($"Çeviri (İngilizce): {translatedText}");
            Console.WriteLine();
        }
        else
        {
            Console.Write("Beklenmeyen bir hata oluştu");
        }
    }

    private static async Task<string> TranslateTextToEnglish(string text, string apiKey)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new {role="system",content="You are a helpful translator."},
                    new {role="user",content= $"Please translate this text to English: {text}"}
                }
            };

            string jsonBody = JsonConvert.SerializeObject(requestBody); // JSON'a çevir
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"); // İçeriği ayarla


            try
            {
                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content); // API'ye istek gönder
                string responseString = await response.Content.ReadAsStringAsync();

                dynamic responseObject = JsonConvert.DeserializeObject(responseString); // Yanıtı JSON'dan çöz
                string translation = responseObject.choices[0].message.content; // Çeviriyi al

                return translation; // Çeviriyi döndür 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                return null;
            }
        }
    }
}