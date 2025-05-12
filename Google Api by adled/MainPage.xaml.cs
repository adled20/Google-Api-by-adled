using System.Collections;
using System.Text.Json;

namespace Google_Api_by_adled
{
    public partial class MainPage : ContentPage
    {
        private List<string> items;
        private IEnumerable filteredItems;

        public MainPage()
        {
            InitializeComponent();
          


        }
        private async Task GetWeatherAsync(string city)
        {
            string apiKey = "99cb1ff9e6d34469819161934250905"; 
            string url = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";
            string forecastUrl = $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={city}&days=5&aqi=no";
            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var weather = JsonSerializer.Deserialize<WeatherResponse>(json);

                // Mostrar resultados
                Ciudad.Text = $"{weather.location.name},{weather.location.country}";

                Temperatura.Text = $"{weather.current.temp_c}°C ";
                   Estado.Text= $"- {weather.current.condition.text}";
                Sensacion.Text = $"Sensación: {weather.current.feelslike_c}°C";
                Humedad.Text = $"Humedad: {weather.current.humidity}%";
                EstadoIcon.Source = ImageSource.FromUri(
            new Uri($"https:{weather.current.condition.icon}"));
          

            }
            else
            {
                Ciudad.Text = "Error al obtener el clima.";
            }

            var forecastResponse = await client.GetAsync(forecastUrl);
            if (forecastResponse.IsSuccessStatusCode)
            {
                var forecastJson = await forecastResponse.Content.ReadAsStringAsync();
                var forecast = JsonSerializer.Deserialize<ForecastResponse>(forecastJson);

                // Actualizar UI con pronóstico (excluyendo el día actual)
                var nextDays = forecast.forecast.forecastday.Skip(1).Take(4).ToList();

                // Asignar datos a los controles (ejemplo para primer día)
                D1.Text = DateTime.Parse(nextDays[0].date).ToString("ddd");
                ImaD1.Source = ImageSource.FromUri(new Uri($"https:{nextDays[0].day.condition.icon}"));
                EstD1.Text = $"{nextDays[0].day.condition.text}, {nextDays[0].day.avgtemp_c}°C";

                D2.Text = DateTime.Parse(nextDays[1].date).ToString("ddd");
                ImaD2.Source = ImageSource.FromUri(new Uri($"https:{nextDays[1].day.condition.icon}"));
                EstD2.Text = $"{nextDays[1].day.condition.text}, {nextDays[1].day.avgtemp_c}°C";

                D3.Text = DateTime.Parse(nextDays[2].date).ToString("ddd");
                ImaD3.Source = ImageSource.FromUri(new Uri($"https:{nextDays[2].day.condition.icon}"));
                EstD3.Text = $"{nextDays[2].day.condition.text}, {nextDays[2].day.avgtemp_c}°C";

                D4.Text = DateTime.Parse(nextDays[3].date).ToString("ddd");
                ImaD4.Source = ImageSource.FromUri(new Uri($"https:{nextDays[3].day.condition.icon}"));
                EstD4.Text = $"{nextDays[3].day.condition.text}, {nextDays[3].day.avgtemp_c}°C";
                // Repetir para Day2, Day3, Day4...
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

}
