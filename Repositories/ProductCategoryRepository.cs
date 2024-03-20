using PepperShop.Data;
using PepperShop.Models;
using Microsoft.EntityFrameworkCore;

namespace PepperShop.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategories();
        Task<ProductCategory> GetProductCategoryById(int id);
        Task<ProductCategory> AddProductCategory(ProductCategory productCategory);
        Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory);
        Task DeleteProductCategory(int id);
    }

    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly PeppershopDataContext _context;

        public ProductCategoryRepository(PeppershopDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<ProductCategory> AddProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }
    }

}
