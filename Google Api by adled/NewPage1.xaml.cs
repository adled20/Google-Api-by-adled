using System.Text.Json;


namespace Google_Api_by_adled;

public partial class NewPage1 : ContentPage
{
    
	public  NewPage1(int id)
	{
		InitializeComponent();
       Traer(id);
    }
    public async void Traer(int id)
    {
        var traer = await App.dataBase.GetOne(id);
        string apiKey = "99cb1ff9e6d34469819161934250905";
        string url = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={traer.Ciudad}&aqi=no";
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        var weather = JsonSerializer.Deserialize<WeatherResponse>(json);
        Ciudad.Text=traer.Ciudad;
       Sensacion.Text=traer.Sensacion;
       Humedad.Text=traer.Humedad;
       Temperatura.Text=traer.Temperatura;
        Climatxt.Text=traer.Clima;
        Clima.Source = ImageSource.FromUri(
            new Uri($"https:{weather.current.condition.icon}"));
    }
}