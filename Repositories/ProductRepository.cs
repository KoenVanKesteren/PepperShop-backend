using PepperShop.Data;
using PepperShop.Models;
using Microsoft.EntityFrameworkCore;

namespace PepperShop.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<ProductDetail> GetProductDetail(int productId);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly PeppershopDataContext _context;

        public ProductRepository(PeppershopDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductDetail> GetProductDetail(int productId)
        {
            return await _context.ProductDetails.Where(pd => pd.ProductId == productId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int productCategoryId)
        {
            using (_context)
            {
                var query = from p in _context.Products
                            join pcp in _context.ProductCategorieProducts on p.Id equals pcp.ProductId
                            where pcp.ProductCategoryId == productCategoryId
                            select new Product
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                ImageUrl = p.ImageUrl
                            };

                return await query.ToListAsync();
            }
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }

}
