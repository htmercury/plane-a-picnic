using System.Threading.Tasks;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Domain.Services
{
    public interface IOpenWeatherService
    {
        Task<WeatherResourceModel> GetWeatherAsync(int id);
    }
}