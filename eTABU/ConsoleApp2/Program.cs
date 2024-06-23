
using eTABU.Server;
using eTABU.Server.Entity;
using System.Net.Http.Headers;
HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:5113/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

    HttpResponseMessage response = await client.GetAsync(
        "api/TabuModels");
    response.EnsureSuccessStatusCode();

    List<TabuModel> SongResponse = new List<TabuModel>();
    if (response.IsSuccessStatusCode)
    {
        SongResponse = DataSerializer.Deserialize<List<TabuModel>>(await response.Content.ReadAsStringAsync())!;
    }

Console.WriteLine(string.Join(' ', SongResponse.Select(x=>x.MainWord + x.Synonim1 + x.Synonim2)));
Console.ReadLine();
