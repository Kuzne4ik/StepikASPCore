using lesson_3_1_5.Models;
using lesson_3_1_5.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_5.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
        }

        
        public ActionResult Index(Guid? id)
        {
            // Если передан id, ищем корзину с этим id
            if (id != null)
            {
                var order = _ordersRepository.TryGetById(id.Value);

                if (order != null)
                {
                    return View(order);
                }
                    
            }

            throw new NotImplementedException("Order for null params not implemented");
        }

        public ActionResult Create(Guid? userId)
        {
            
            // Если передан id, ищем корзину с этим id
            if (userId != null)
            {
                var cart = _cartsRepository.TryGetByUserId(userId.Value);

                if (cart != null)
                {
                    var order = _ordersRepository.AddOrder(userId.Value, cart);

                    return RedirectToAction("Index", new { id = order.Id });
                }
            }

            throw new NotImplementedException("Create Order for null params not implemented");
        }

        [HttpPost]
        public IActionResult Submit(Guid? id, string userName, string address, string phone)
        {
            if (id == null || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
            {
                return BadRequest("Invalid parameters");
            }

            var order = _ordersRepository.TryGetById(id.Value);
            if  (order != null)
            {
                order.UserName = userName;
                order.Address = address;
                order.Phone = phone;

                _ordersRepository.Update(order);

                // Очистить корзину
                _cartsRepository.Clear(order.UserId);

                return RedirectToAction("Success");
            }
            throw new NotImplementedException("Create Order for null params not implemented");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
