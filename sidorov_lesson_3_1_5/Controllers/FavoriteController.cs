using lesson_3_1_5.Models;
using lesson_3_1_5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_5.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoritesRepository _favoritesRepository;
        private readonly IProductsRepository _productsRepository;

        public FavoriteController(IFavoritesRepository favoritesRepository, IProductsRepository productsRepository)
        {
            _favoritesRepository = favoritesRepository;
            _productsRepository = productsRepository;
        }


        public IActionResult Index(Guid? id)
        {
            Favorite favorite = null;
            if (id != null)
            {
                // Если передан id, ищем favorite с этим id
                favorite = _favoritesRepository.TryGetById(id.Value);
            }
            else
            {
                // Получаем favorite по пользователя id (в данном случае, используем константу)
                favorite = _favoritesRepository.TryGetByUserId(Constants.UserId);
            }
            return View(favorite);
        }


        public IActionResult Add(Guid? userId = null, Guid? productId = null)
        {
            // Если передан id, ищем с этим id
            if (userId != null && productId != null)
            {
                var product = _productsRepository.TryGetById(productId.Value);
                if (product == null)
                {
                    return NotFound();
                }

                var favorite = _favoritesRepository.AddFavoriteItem(userId.Value, product);

                // Views/Favorite/Details.cshtml - для отображения одного товара
                if (favorite != null) 
                    return RedirectToAction("Index", new { id = favorite.Id});
            }
            throw new NotImplementedException("Favorite for null params not implemented");
        }

        public IActionResult Remove(Guid? userId = null, Guid? productId = null)
        {
            // Если передан id, ищем favorite с этим id
            if (userId != null && productId != null)
            {
                var product = _productsRepository.TryGetById(productId.Value);
                if (product == null)
                {
                    return NotFound();
                }

                var favorite = _favoritesRepository.RemoveFavoriteItem(userId.Value, product.Id);

                // Views/Favorite/Details.cshtml - для отображения одного товара
                if (favorite != null)
                    return RedirectToAction("Index", new { id = favorite.Id });
            }
            throw new NotImplementedException("Favorite for null params not implemented");
        }

        public IActionResult Clear(Guid? userId = null)
        {
            // Если передан id, ищем favorite с этим id
            if (userId != null)
            {
                var favorite = _favoritesRepository.Clear(userId.Value);

                // Views/Favorite/Details.cshtml - для отображения одного товара
                if (favorite != null)
                    return RedirectToAction("Index", new { id = favorite.Id });
            }
            throw new NotImplementedException("Favorite for null params not implemented");
        }
    }
}
