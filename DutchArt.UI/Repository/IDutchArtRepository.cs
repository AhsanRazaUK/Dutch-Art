using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchArt.Data.Entities;

namespace DutchArt.Repository
{
    public interface IDutchArtRepository
    {
        IQueryable<Product> GetProducts();
        Task<Product> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsAsync(string ArtId);
        Task<IEnumerable<Art>> GetArtsAsync();
        IQueryable<Art> GetArts();
        Task<Art> GetArtAsync(string id);        
    }
}