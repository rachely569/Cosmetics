using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cosmetics_Bll;
using Cosmetics_Dal.Models;
using CosmeticsDTO;

namespace Cosmetics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersBll usersBLL;
        IMapper mapper;

        public UsersController(IUsersBll _usersBLL)
        {
            usersBLL = _usersBLL;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            mapper = config.CreateMapper();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UsersDTO> Get()
        {
            List<Users> list = usersBLL.GetAllUsers();
            return mapper.Map<IEnumerable<UsersDTO>>(list);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UsersDTO Get(int id)
        {
            return mapper.Map<UsersDTO>(usersBLL.GetUsersById(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UsersDTO newUser)
        {
            Users user = mapper.Map<Users>(newUser);
            usersBLL.AddUsers(user);
        }

        // PUT api/<UsersController>
        [HttpPut]
        public void Put([FromBody] UsersDTO updateUser)
        {
            Users user = mapper.Map<Users>(updateUser);
            usersBLL.UpdateUsers(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usersBLL.DeleteUser(id);
        }
    }
}