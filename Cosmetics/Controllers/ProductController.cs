using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cosmetics_Bll;
using Cosmetics_Dal.Models;
using CosmeticsDTO;

namespace Cosmetics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsBll productsBll;
        IMapper mapper;

        public ProductsController(IProductsBll _productsBll)
        {
            productsBll = _productsBll;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            mapper = config.CreateMapper();
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            List<Products> list = productsBll.GetAllProducts();
            return mapper.Map<IEnumerable<ProductDTO>>(list);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return mapper.Map<ProductDTO>(productsBll.GetProductsById(id));
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] ProductDTO newProduct)
        {
           Products product = mapper.Map<Products>(newProduct);
           productsBll.AddProducts(product);
        }

        // PUT: api/Products
        [HttpPut]
        public void Put([FromBody] ProductDTO updateProduct)
        {
            Products product = mapper.Map<Products>(updateProduct);
            productsBll.UpdateProducts(product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productsBll.DeleteProducts(id);
        }
    }
}