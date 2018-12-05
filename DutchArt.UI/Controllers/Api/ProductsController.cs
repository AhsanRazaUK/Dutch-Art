using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchArt.Data.Entities;
using DutchArt.Models;
using DutchArt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DutchArt.Repository;

namespace DutchArt.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IDutchArtRepository repository;
        private readonly IMapper mapper;
        private readonly ILinksBuilder linksBuilder;

        public ProductsController(ILogger<ProductsController> logger, IDutchArtRepository repository, IMapper mapper, ILinksBuilder linksBuilder)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
            this.linksBuilder = linksBuilder;
        }
        // GET: api/Products
        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAsync(int page = 1, int pageSize = 10)
        {
            logger.LogInformation("In GetAllProducts");

            try
            {
                int skip = (page - 1) * pageSize;
                int take = pageSize;
                var products = await repository.GetProductsAsync();
                int total = products.Count();

                var paginatedProducts = products.Skip(skip).Take(take).ToList();

                var productsWithLinks = paginatedProducts.Select(p => GetProductViewModel(p));

                var PageLinks = linksBuilder.CreatePageLinks(Url, "GetAllProducts", null, page, pageSize, total);

                return Ok(
                    new
                    {
                        TotalRecords = total,
                        PageSize = pageSize,
                        Links = new
                        {
                            PageLinks.First,
                            PageLinks.Last,
                            PageLinks.Next,
                            PageLinks.Previous
                        },
                        products = productsWithLinks
                    }
                );
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
            }
        }

        private ProductViewModel GetProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Links = linksBuilder.CreateEntityLinks(Url, product.Id,
                new List<RouteMethods>()
                {
                    new RouteMethods() {
                        HttpMethod= HttpMethods.Get,
                        RouteMethodName = "GetProduct"
                    }
                }),
                Id = product.Id,
                Category = product.Category,
                Size = product.Size,
                Price = product.Price,
                Title = product.Title,
                Art = product.Art
            };
        }


        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetAsync(int id)
        {
            logger.LogInformation($"In Product Get For Id = {id}");

            try
            {

                var FindProduct = await repository.GetProductAsync(id);

                var product = GetProductViewModel(FindProduct);

                return Ok(new
                {
                    product
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
            }
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
