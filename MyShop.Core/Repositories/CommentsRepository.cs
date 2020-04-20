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
    public class CommentsRepository: ICommentsRepository
    {
        private readonly ShopDbContext _context;

        public CommentsRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<List<Comments>> GetByProductIdAsync(Guid id)
        {
            return await _context.Comments.Where(x => x.ProductId == id).ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Comments comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment == null)
                return false;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
