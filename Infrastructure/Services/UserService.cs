using System;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IRepository<Favorite> _favoriteRepository;
        private readonly IRepository<Review> _reviewRepository;

        public UserService(
            IUserRepository userRepository,
            IPurchaseRepository purchaseRepository,
            IRepository<Favorite> favoriteRepository,
            IRepository<Review> reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<UserProfileModel> GetUserProfile(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user == null) return null;

            return new UserProfileModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<IEnumerable<PurchaseModel>> GetPurchases(int userId)
        {
            var purchases = await _purchaseRepository.GetPurchasesByUser(userId);

            return purchases.Select(p => new PurchaseModel
            {
                MovieId = p.MovieId,
                Title = p.Movie.Title,
                PosterUrl = p.Movie.PosterUrl,
                PurchaseDate = p.PurchaseDateTime,
                Price = p.TotalPrice
            });
        }

        public async Task<bool> IsMoviePurchased(int userId, int movieId)
        {
            return await _purchaseRepository.IsMoviePurchased(userId, movieId);
        }

        public async Task<IEnumerable<FavoriteModel>> GetFavorites(int userId)
        {
            var favorites = await _favoriteRepository.GetAll();

            return favorites
                .Where(f => f.UserId == userId)
                .Select(f => new FavoriteModel
                {
                    MovieId = f.MovieId,
                    Title = f.Movie.Title,
                    PosterUrl = f.Movie.PosterUrl
                });
        }

        public async Task AddFavorite(FavoriteRequestModel model)
        {
            await _favoriteRepository.Add(new Favorite
            {
                MovieId = model.MovieId,
                UserId = model.UserId
            });
        }

        public async Task RemoveFavorite(FavoriteRequestModel model)
        {
            var favorites = await _favoriteRepository.GetAll();
            var fav = favorites.FirstOrDefault(f => f.MovieId == model.MovieId && f.UserId == model.UserId);

            if (fav != null)
                await _favoriteRepository.Delete(fav.MovieId);
        }

        public async Task AddReview(ReviewRequestModel model)
        {
            await _reviewRepository.Add(new Review
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                Rating = model.Rating,
                ReviewText = model.ReviewText
            });
        }

        public async Task UpdateReview(ReviewRequestModel model)
        {
            await _reviewRepository.Update(new Review
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                Rating = model.Rating,
                ReviewText = model.ReviewText
            });
        }

        public async Task DeleteReview(int userId, int movieId)
        {
            var reviews = await _reviewRepository.GetAll();
            var review = reviews.FirstOrDefault(r => r.UserId == userId && r.MovieId == movieId);

            if (review != null)
                await _reviewRepository.Delete(review.MovieId);
        }
        public async Task PurchaseMovie(PurchaseRequestModel model)
        {
            var purchase = new Purchase
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                TotalPrice = model.TotalPrice,
                PurchaseDateTime = DateTime.UtcNow
            };

            await _purchaseRepository.Add(purchase);
        }

    }
}
