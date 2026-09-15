using lesson_3_1_5.Models;
using lesson_3_1_5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_5.Repositories
{
    public class FavoritesRepository: IFavoritesRepository
    {
        public static List<Favorite>? _favorites = new List<Favorite>();


        public FavoritesRepository()
        {
        }

        public List<Favorite>? GetAll()
        {
            return _favorites;
        }

        public Favorite TryGetByUserId(Guid userId)
        {
            var favorite = _favorites?.FirstOrDefault(t => t.UserId == userId);
            // Если корзина для данного пользователя не найдена, создаем новую
            if (favorite == null)
            {
                favorite = new Favorite(Guid.NewGuid(), Constants.UserId);
                _favorites?.Add(favorite);
            }

            return favorite;
        }

        public Favorite? TryGetById(Guid id)
        {
            return _favorites?.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Favorite favorite)
        {
            var targetFavorite = TryGetById(favorite.Id);
            if (targetFavorite != null)
            {
                targetFavorite.Products = targetFavorite.Products;
                return;
            }
            
            return;
        }

        public Favorite? AddFavoriteItem(Guid userId, Product product)
        {
            var favorite = TryGetByUserId(userId);


            if (favorite.Products.Any(t => t.Id == product.Id))
            {
                // уже есть такой товар в избранном, не добавляем его повторно
                return favorite;
            }
            favorite.Products.Add(product);

            Update(favorite);
            return favorite;
        }

        public Favorite? RemoveFavoriteItem(Guid userId, Guid productId)
        {
            var favorite = TryGetByUserId(userId);

            var productToDelete = favorite.Products.FirstOrDefault(t => t.Id == productId);
            if (productToDelete != null){
                favorite.Products.Remove(productToDelete);
                Update(favorite);
            }
            return favorite;
        }

        public Favorite? Clear(Guid userId)
        {
            var favorite = TryGetByUserId(userId);

            favorite.Products.Clear();

            Update(favorite);
            return favorite;
        }
    }

    public interface IFavoritesRepository
    {
        List<Favorite>? GetAll();

        Favorite TryGetByUserId(Guid userId);

        Favorite? TryGetById(Guid id);

        void Update(Favorite favorite);

        Favorite? AddFavoriteItem(Guid userId, Product product);

        Favorite? RemoveFavoriteItem(Guid userId, Guid productId);

        Favorite? Clear(Guid userId);
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        