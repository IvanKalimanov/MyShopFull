using Microsoft.EntityFrameworkCore;
using MyShop.Core.EF;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _context;
        private readonly IProductRepository _bookRepo;

        public CategoryRepository(ShopDbContext context, IProductRepository bookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _context.Categories
                .Include(x => x.Products)
                .FirstAsync(c => c.Id == id);
        }

        public async Task<Category> GetByBookAsync(Guid id)
        {
            Product book = await _bookRepo.GetByIdAsync(id);
            if (book == null)
                throw new ApplicationException();
            return await _context.Categories
                .Include(x => x.Products)
                .FirstAsync(c => c.Id == book.CategoryId);
        }

        public async Task<Category> CreateAsync(Category item)
        {
            var result = await _context.Categories.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateAsync(Category item)
        {
            _context.Categories.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
