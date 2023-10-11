using System;
using WeatherForecastDataGenerator.Models;

namespace WeatherForecastDataGeneratorMock.Services
{
    public class WeatherForecastGenerator
    {
        private readonly int _citiesCount;
        private readonly List<WeatherToday> _weatherTodayList;
        private readonly Random _randomGenerator;

        public int CitiesCount => _citiesCount;

        public WeatherForecastGenerator(int citiesCount)
        {
            _citiesCount = citiesCount;
            _weatherTodayList = new List<WeatherToday>();
            _randomGenerator = new Random();
        }

        public List<WeatherToday> GetGeneratedWeatherForecast()
        {
            for(int i = 1; i <= _citiesCount; i++)
            {
                var weather = new WeatherToday()
                {
                    Id = i,
                    CityId = _randomGenerator.Next(1, 10),
                    Scale = _randomGenerator.Next(2) % 2 == 0 ? "°C" : "°F"
                };
                weather.Temperature = weather.Scale.Equals("°C") ? _randomGenerator.Next(40) : _randomGenerator.Next(50, 100);
                _weatherTodayList.Add(weather);
            }
            return _weatherTodayList;
        }
    }
}
