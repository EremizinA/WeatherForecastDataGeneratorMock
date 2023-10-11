// See https://aka.ms/new-console-template for more information
using WeatherForecastDataGeneratorMock.Services;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Newtonsoft.Json;


const int Port = 51010;
const string WeatherForecastAppUrl = "/WeatherForecast/GetAllWeatherForecastForToday";
var server = WireMockServer.Start(Port);

Console.WriteLine($"Wiremock server is listening on {server.Url}");

var weatherForecast = new WeatherForecastGenerator(10);
var weatherForecasts = weatherForecast.GetGeneratedWeatherForecast();
//var weatherForecastsJson = JsonConvert.SerializeObject(weatherForecasts);

server
  .Given(
    Request.Create().WithPath(WeatherForecastAppUrl).UsingGet()
  )
  .RespondWith(
    Response.Create()
      .WithStatusCode(200)
      .WithHeader("Content-Type", "application/json")
      .WithBody(JsonConvert.SerializeObject(weatherForecasts))
  );

Console.ReadKey();
