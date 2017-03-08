using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCqrs.Contracts;
using SimpleCqrs.DataAccess;

namespace SimpleCqrs.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductQueryService queryService;
        private readonly Repository<Product> repository;

        public ProductController(ProductQueryService queryService, Repository<Product> repository)
        {
            this.queryService = queryService;
            this.repository = repository;
        }

        [HttpGet]
        [Route("api/product")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await queryService.GetProducts();
            var items = products
                    .GroupBy(p => p.Id)
                    .Select(p => new
                    {
                        Product = p.First(),
                        Categories = p
                            .Where(c => c.CategoryName != null)
                            .Select(c => c.CategoryName)
                            .ToArray()
                    })
                    .Select(p => new GetProductsItem
                    {
                        Id = p.Product.Id,
                        Title = p.Product.Title,
                        Price = p.Product.Price,
                        Categories = p.Categories
                    });
            return Ok(new GetProductsResult
            {
                Items = items
            });
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute]GetProductById query)
        {
            var products = await queryService.GetProductById(query);
            var product = products.FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            var result = new GetProductByIdResult
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Categories = products
                    .Where(c => c.CategoryName != null)
                    .Select(c => c.CategoryName)
                    .ToArray()
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("api/product")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProduct dto)
        {
            var product = new Product
            {
                Title = dto.Title,
                Price = dto.Price
            };
            await repository.Create(product);
            return Created($"api/product/{product.Id}", dto);
        }

        [HttpPut]
        [Route("api/product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]UpdateProduct dto)
        {
            var product = await repository.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Title = dto.Title;
            product.Price = dto.Price;
            await repository.Update(product);
            return Ok();
        }

        [HttpDelete]
        [Route("api/product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repository.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            await repository.Delete(product);
            return NoContent();
        }
    }
}
