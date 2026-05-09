using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        Task<UserProfileModel> GetUserProfile(int userId);

        Task<IEnumerable<PurchaseModel>> GetPurchases(int userId);
        Task<bool> IsMoviePurchased(int userId, int movieId);

        Task<IEnumerable<FavoriteModel>> GetFavorites(int userId);
        Task AddFavorite(FavoriteRequestModel model);
        Task RemoveFavorite(FavoriteRequestModel model);

        Task AddReview(ReviewRequestModel model);
        Task UpdateReview(ReviewRequestModel model);
        Task DeleteReview(int userId, int movieId);

        // ⭐ REQUIRED FOR PURCHASE BUTTON TO WORK
        Task PurchaseMovie(PurchaseRequestModel model);
    }
}
