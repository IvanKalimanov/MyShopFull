using Microsoft.EntityFrameworkCore;
using MyShop.Core.EF;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetByCategoryAsync(Guid id)
        {
            return await _context.Products.Where(b => b.CategoryId == id).ToListAsync();
        }

        public async Task<List<Product>> GetByListIdAsync(List<Guid> id)
        {
            List<Product> products = new List<Product>();
            foreach (Guid a in id)
            {
                products.Add(await _context.Products.FindAsync(a));
            }
            return products;
        }

        public async Task<bool> AddComment(Comments comment)
        {
            var pr = await _context.Products.FirstOrDefaultAsync(x => x.Id == comment.ProductId);
            if (pr != null)
            {
                await _context.Comments.AddAsync(comment);
                pr.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
              
        }
        public async Task<Product> CreateAsync(Product item)
        {
            var result = await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateAsync(Product item)
        {
            _context.Products.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Product book = await _context.Products.FindAsync(id);
            if (book == null)
                return false;
            _context.Products.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
