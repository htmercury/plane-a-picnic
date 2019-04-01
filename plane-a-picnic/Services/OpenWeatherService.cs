using System.Threading.Tasks;
using plane_a_picnic.Domain.Repositories;
using plane_a_picnic.Domain.Services;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IOpenWeatherRepository _openWeatherRepository;

        public OpenWeatherService(IOpenWeatherRepository openWeatherRepository)
        {
            _openWeatherRepository = openWeatherRepository;
        }

        public async Task<WeatherResourceModel> GetWeatherAsync(int id)
        {
            return await _openWeatherRepository.GetWeather(id);
        }
    }
}