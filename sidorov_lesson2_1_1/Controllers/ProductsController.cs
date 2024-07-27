using lesson2_1_1.Models;
using lesson2_1_1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson2_1_1.Controllers
{

    public class ProductController : BaseApiController
    {

        private readonly ILogger<ProductController> _logger;
        private readonly ProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _productRepository = new ProductRepository();
        }

        [HttpGet("{id}")]
        [HttpGet]
        public string getById(int id)
        {
            var product = _productRepository.TryGetById(id);
            if(product != null)
                return product.ToString();
            return $"Not found by {id}";

        }

        
    }
}
