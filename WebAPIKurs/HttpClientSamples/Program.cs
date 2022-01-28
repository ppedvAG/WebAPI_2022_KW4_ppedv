#nullable disable

using ControllerSample.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

Console.WriteLine("Drücken Sie einen Key, wenn der Service verfügbar");
Console.ReadKey();


string baseURL = "https://localhost:7233/api/movies/";
HttpClient client = new HttpClient();

#region HttpClient call Get-Methode (JSON Sample)
//Initialisierung 
HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, baseURL);
//Call WebAPI -> Get Methode
HttpResponseMessage responseMessage = await client.SendAsync(httpRequestMessage);


//Read Result
string jsonString = await responseMessage.Content.ReadAsStringAsync();
Console.WriteLine(jsonString);
#endregion

//Direkte Variante mit Get 
//HttpResponseMessage responseMessage1 = await client.GetAsync(baseURL);


#region HttpClient with XML

HttpRequestMessage requestMessage1 = new HttpRequestMessage(HttpMethod.Get, baseURL);
//requestMessage1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
requestMessage1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
HttpResponseMessage responseMessage1 = await client.SendAsync(requestMessage1);
string xmlString = await responseMessage1.Content.ReadAsStringAsync();
Console.WriteLine(xmlString);

#endregion

Console.WriteLine("Weiter mit KeyPress");
Console.ReadKey();


HttpClientRequestSamples httpClientRequestSamples = new HttpClientRequestSamples(); 

Movie movie = new Movie();
movie.Title = "ES";
movie.Description = "Clown sucht doch nur seine Schminke";
movie.Price = 8.99m;

httpClientRequestSamples.InsertMovie(movie);

httpClientRequestSamples.GetAll();


public class HttpClientRequestSamples
{
    private HttpClient httpClient;
    private string baseURL = "https://localhost:7233/api/Movies/";

    

    public HttpClientRequestSamples()
    {
        httpClient = new HttpClient();
    }

    public async void GetAll()
    {
        Console.WriteLine("HttpClient.GetAsync Beispiel mit Liste von Movies");

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(baseURL);
        string jsonText = await httpResponseMessage.Content.ReadAsStringAsync();
        
        if (!string.IsNullOrEmpty(jsonText))
        {
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonText);


            foreach(Movie currentMovie in movies)
            {
                Console.WriteLine($"{currentMovie.Title} - {currentMovie.Description} \t Preis: {currentMovie.Price}");
            }
        }
        
        Console.WriteLine("Weiter mit Key");
        Console.ReadKey();
    }

    public async void GetById(int id)
    {
        Console.WriteLine("HttpClient.GetAsync Beispiel mit einem Movie");
        //Format -> https://localhost:7233/api/movies/123
        string extendetUrl = baseURL + id.ToString();

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(extendetUrl);
        string jsonText = await httpResponseMessage.Content.ReadAsStringAsync();

        Movie movie = JsonConvert.DeserializeObject<Movie>(jsonText);


        Console.WriteLine($"{movie.Title} - {movie.Description} \t Preis: {movie.Price}");
        Console.WriteLine("Weiter mit Key");
        Console.ReadKey();
    }

    public async void InsertMovie(Movie movie)
    {
        Console.WriteLine("HttpClient.PostAsync Beispiel");
        #region Hinzufügen eines Movies
        string jsonText = JsonConvert.SerializeObject(movie);

        //HttpRequest bekommt ein Movie Objekt in den Body hinzugefügt
        StringContent body = new StringContent(jsonText, Encoding.UTF8, "application/json");
        HttpResponseMessage httpResponse = await httpClient.PostAsync(baseURL, body);

        Console.WriteLine(httpResponse.StatusCode);
        #endregion

        string jsonResult = await httpResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Response von PostAsync" + jsonResult);


        Console.WriteLine("Weiter mit Key");
        Console.ReadKey();
    }

    public async void UpdateMovie(Movie movie)
    {
        string extendetUrl = baseURL + movie.Id.ToString();
        string jsonText = JsonConvert.SerializeObject(movie);

        StringContent body = new StringContent(jsonText, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PutAsync( extendetUrl, body);
    }

    public async void DeleteMovie(int id)
    {
        string extendetUrl = baseURL + id.ToString();
        HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync(extendetUrl);
    }
}