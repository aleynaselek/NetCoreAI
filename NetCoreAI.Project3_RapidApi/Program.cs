using NetCoreAI.Project3_RapidApi.ViewModels;
using Newtonsoft.Json; 

var client = new HttpClient();
List<ApiSeriesViewModel> apiSeriesViewModels = new List<ApiSeriesViewModel>();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
    Headers =
    {
        { "x-rapidapi-key", "7d71b3cb13mshb4edafd5de17486p12b6dajsn611119cdee76" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    apiSeriesViewModels = JsonConvert.DeserializeObject<List<ApiSeriesViewModel>>(body);
    foreach (var item in apiSeriesViewModels)
    {
        Console.WriteLine(item.rank + "-" + item.title + " - Film Puanı:" + item.rating + " - Yapım Yılı:" + item.year);
    } 
}

Console.ReadLine();