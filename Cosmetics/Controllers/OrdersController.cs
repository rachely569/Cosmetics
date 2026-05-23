using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cosmetics_Bll;
using Cosmetics_Dal.Models;
using CosmeticsDTO;

namespace Cosmetics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
         IOrdersBll ordersBll;
         IMapper mapper;

        public OrdersController(IOrdersBll _ordersBll)
        {
            ordersBll = _ordersBll;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            mapper = config.CreateMapper();
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrdersDTO> Get()
        {
            List<Orders> list = ordersBll.GetAllOrders();
            return mapper.Map<IEnumerable<OrdersDTO>>(list);
        }

        // GET: api/Orders/5
        [HttpGet("{id:int}")]
        public OrdersDTO Get(int id)
        {
            return mapper.Map<OrdersDTO>(ordersBll.GetOrdersById(id));
        }

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] OrdersDTO newOrder)
        {
            Orders order = mapper.Map<Orders>(newOrder);
            ordersBll.AddOrders(order);
        }
        // PUT: api/Orders
        [HttpPut]
        public void Put([FromBody] OrdersDTO updateOrder)
        {
            Orders order = mapper.Map<Orders>(updateOrder);
            ordersBll.UpdateOrders(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ordersBll.DeleteOrders(id);
        }
    }
}