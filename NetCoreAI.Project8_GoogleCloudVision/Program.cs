using Google.Cloud.Vision.V1;
using static Google.Protobuf.Reflection.GeneratedCodeInfo.Types;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Resim yolunu giriniz:");
        Console.WriteLine();
        string imagePath = Console.ReadLine();

        string credentialPath = "C:/Users/Aleyna/Downloads/flash-rope-413405-46aff5e9923f.json";

        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath); // Google Cloud Vision API kimlik bilgileri

        try
        {
            var client = ImageAnnotatorClient.Create(); // Google Cloud Vision API client
            var image = Image.FromFile(imagePath); // Resmi oku
            var response = client.DetectText(image);  // Resimdeki metni tespit et

            Console.WriteLine();
            Console.WriteLine("Resimdeki Metin:");
            Console.WriteLine();
            Console.WriteLine(response[0].Description); // Metni ekrana yazdır
            //foreach (var annotation in response)
            //{
            //    if (!string.IsNullOrEmpty(annotation.Description))
            //    {
            //        Console.WriteLine(annotation.Description); // Metni ekrana yazdır
            //    }
            //}
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu {ex.Message}");
        } 
    }
}