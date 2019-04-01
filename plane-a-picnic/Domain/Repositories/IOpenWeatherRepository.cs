using System.Threading.Tasks;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Domain.Repositories
{
    public interface IOpenWeatherRepository
    {
        Task<WeatherResourceModel> GetWeather(int id);
    }
}