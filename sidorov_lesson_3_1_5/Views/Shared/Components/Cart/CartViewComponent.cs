using lesson_3_1_5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_5.Views.Shared.Components.Cart
{
    public class CartViewComponent: ViewComponent
    {
        private readonly ICartsRepository _cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cartItemsCount = _cartsRepository.GetItemsCount(Constants.UserId);

            return View("Cart", cartItemsCount);
        }
    }
}
