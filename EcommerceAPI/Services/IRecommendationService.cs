using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceAPI.Services
{
    public interface IRecommendationService
    {
        Task<IEnumerable<int>> GetRecommendationsAsync(int userId, int numberOfRecommendations = 5);
    }
}