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
                    "data/2.5/forecast?lat={0}&lon={1}&appid={2}",
                    target.LatitudeDeg,
                    target.LongitudeDeg,
                    _config.Value.OpenWeatherKey
                )
            );
            
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<WeatherResourceModel>();

            var len = result.List.Select(l => DateTime.Parse(l.DtTxt).Day).Distinct().Count();
            var list = new List[len];
            // filter forecast entries by distinct Date.
            int idx = 0;
            var lastDay = -1;
            for (int i = 0; i < result.List.Length; i++)
            {
                var currDay = DateTime.Parse(result.List[i].DtTxt).Day;
                if (currDay > lastDay) {
                    lastDay = currDay;
                    list[idx] = result.List[i];
                    idx++;
                }
            }

            result.List = list;

            return result;
        }
    }
}