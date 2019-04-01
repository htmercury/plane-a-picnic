using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;
using plane_a_picnic.ResourceModels;
using plane_a_picnic.Settings.Options;

namespace plane_a_picnic.Repositories
{
    public class OpenWeatherRepository : BaseRepository, IOpenWeatherRepository
    {
        private readonly IOptions<OpenWeatherOptions> _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenWeatherRepository(ModelContext context, IHttpClientFactory httpClientFactory
            , IOptions<OpenWeatherOptions> config) : base(context)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherResourceModel> GetWeather(int id)
        {
            var target = await _context.Airports
                .Where(airport => airport.AirportId == id)
                .FirstOrDefaultAsync();
            var httpClient = _httpClientFactory.CreateClient("openWeather");
            
            var response = await httpClient.GetAsync(
                string.Format(
                    "data/2.5/weather?lat={0}&lon={1}&APPID={2}",
                    target.LatitudeDeg,
                    target.LongitudeDeg,
                    _config.Value.Key
                )
            );
            
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<WeatherResourceModel>();

            return result;
        }
    }
}