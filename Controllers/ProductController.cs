using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PepperShop.Models;
using PepperShop.Repositories;

namespace PepperShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpGet("productDetail/{productId}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(int productId)
        {
            var productDetail = await _productRepository.GetProductDetail(productId);
            if (productDetail == null) return NotFound();
            return productDetail;
        }

        [HttpGet("byProductCategoryId/{productCategoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByFilter(int productCategoryId)
        {
            var products = await _productRepository.GetProductsByCategoryId(productCategoryId);
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var newProduct = await _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            await _productRepository.UpdateProduct(product);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteProduct(id);
            return NoContent();
        }
    }

}
