using System.Text.Json;

namespace Google_Api_by_adled;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
    private async Task GetWeatherAsync(string city)
    {
        string apiKey = "99cb1ff9e6d34469819161934250905"; // ?? Reemplaza por tu API Key
        string url = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var weather = JsonSerializer.Deserialize<WeatherResponse>(json);

            // Mostrar resultados
            WeatherLabel.Text = $"Clima en {weather.location.name}, {weather.location.country}:\n" +
                                $"{weather.current.temp_c}°C - {weather.current.condition.text}";
        }
        else
        {
            WeatherLabel.Text = "Error al obtener el clima.";
        }
    }

    private async void OnGetWeatherClicked(object sender, EventArgs e)
    {
        var city = CityEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(city))
        {
            await GetWeatherAsync(city);
        }
    }
}