using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IReviewService
    {
        Task AddReview(ReviewRequestModel model);
        Task UpdateReview(ReviewRequestModel model);
        Task DeleteReview(int userId, int movieId);

        Task<IEnumerable<ReviewResponseModel>> GetReviewsByMovie(int movieId);
    }
}
