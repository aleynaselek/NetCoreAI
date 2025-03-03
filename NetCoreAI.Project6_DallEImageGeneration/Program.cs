using Newtonsoft.Json;
using System.Text;

class Program
{
    public static async Task Main(string[] args)
    {
        var apiKey = "";

        Console.WriteLine("Example prompts: ");
        string prompt = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestBody = new
            {
                prompt = prompt,
                n = 1,
                size = "1024x1024"
            };

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var form = new MultipartFormDataContent();
            form.Add(new StringContent(prompt), "prompt");
            form.Add(new StringContent("1"), "num_outputs");

            var response = await client.PostAsync("https://api.openai.com/v1/engines/davinci-codex/completions", form);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Result: ");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"An error occurred: {response.StatusCode}");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}