using DutchArt.Data;
using DutchArt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchArt.Repository
{
    public class DutchArtRepository : IDutchArtRepository
    {
        private readonly ILogger logger;
        private DutchArtContext context;

        public DutchArtRepository(ILogger<DutchArtRepository> logger, DutchArtContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return context.Products
                .Include(p => p.Art)
                .AsNoTracking().AsQueryable();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await context.Products
                        .Include(p => p.Art)
                        .Where(p => p.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Products
                .Include(p => p.Art)
                .OrderBy(p=> p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string ArtId)
        {
            return await context.Products
                .Where(p => string.Equals(p.Art.ArtId, ArtId, StringComparison.InvariantCultureIgnoreCase))                
                .ToListAsync();
        }

        public IQueryable<Art> GetArts()
        {
            return context.Arts
                .AsNoTracking().AsQueryable();
        }

        public async Task<IEnumerable<Art>> GetArtsAsync()
        {
            return await context.Arts
                  .ToListAsync();
        }

        public async Task<Art> GetArtAsync(string id)
        {
            return await context.Arts
                     .Where(a => string.Equals(a.ArtId, id, StringComparison.InvariantCultureIgnoreCase))                     
                     .FirstOrDefaultAsync();
        }
    }
}
