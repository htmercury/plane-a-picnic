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
                    _config.Value.Key
                )
            );
            
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<WeatherResourceModel>();

            var len = result.List.Select(l => l.DtTxt.Date).Distinct().Count();
            var list = new List[len];
            // filter forecast entries by distinct Date.
            int idx = 1;
            var last = result.List[0].DtTxt.Date;
            list[0] = result.List[0];
            for (int i = 1; i < result.List.Length; i++)
            {
                if (result.List[i].DtTxt.Date != last) {
                    last = result.List[i].DtTxt.Date;
                    list[idx] = result.List[i];
                    idx++;
                }
            }

            result.List = list;

            return result;
        }
    }
}