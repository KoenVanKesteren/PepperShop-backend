using Microsoft.AspNetCore.Mvc;
using PepperShop.Models;
using PepperShop.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace PepperShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> Get()
        {
            var ProductCategory = await _productCategoryRepository.GetAllProductCategories();
            return Ok(ProductCategory);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetById(int id)
        {
            var productCategory = await _productCategoryRepository.GetProductCategoryById(id);
            if (productCategory == null) return NotFound();
            return productCategory;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> Create(ProductCategory productCategory)
        {
            var newProductCategory = await _productCategoryRepository.AddProductCategory(productCategory);
            return CreatedAtAction(nameof(GetById), new { id = newProductCategory.Id }, newProductCategory);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id) return BadRequest();
            await _productCategoryRepository.UpdateProductCategory(productCategory);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productCategoryRepository.DeleteProductCategory(id);
            return NoContent();
        }
    }

}
