//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Cosmetics_Bll;
//using Cosmetics_Dal.Models;
//using CosmeticsDTO;
//using System.Collections.Generic;
//using System.Linq;

//namespace Cosmetics.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        IUsersBll usersBLL;
//        IMapper mapper;

//        public UsersController(IUsersBll _usersBLL)
//        {
//            usersBLL = _usersBLL;
//            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
//            mapper = config.CreateMapper();
//        }

//        // GET: api/<UsersController>
//        [HttpGet]
//        public IEnumerable<UsersDTO> Get()
//        {
//            List<Users> list = usersBLL.GetAllUsers();
//            return mapper.Map<IEnumerable<UsersDTO>>(list);
//        }

//        // GET api/<UsersController>/5
//        [HttpGet("{id}")]
//        public UsersDTO Get(int id)
//        {
//            return mapper.Map<UsersDTO>(usersBLL.GetUsersById(id));
//        }

//        // POST api/<UsersController>
//        [HttpPost]
//        public void Post([FromBody] UsersDTO newUser)
//        {
//            Users user = mapper.Map<Users>(newUser);
//            usersBLL.AddUsers(user);
//        }

//        // PUT api/<UsersController>
//        [HttpPut]
//        public void Put([FromBody] UsersDTO updateUser)
//        {
//            Users user = mapper.Map<Users>(updateUser);
//            usersBLL.UpdateUsers(user);
//        }

//        // DELETE api/<UsersController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            usersBLL.DeleteUser(id);
//        }

//        // 🎯 פונקציית התחברות חדשה ומאובטחת המבוצעת בצד השרת
//        // POST: api/Users/login
//        [HttpPost("login")]
//        public ActionResult<UsersDTO> Login([FromBody] UsersLoginModel loginModel)
//        {
//            // שליפת כל המשתמשים מהשכבה הלוגית לחיפוש
//            List<Users> list = usersBLL.GetAllUsers();

//            // חיפוש המשתמש לפי מייל או שם משתמש בצורה שאינה רגישה לאותיות גדולות/קטנות
//            var foundUser = list.FirstOrDefault(u =>
//                (u.Email?.ToLower() == loginModel.Email?.ToLower() || u.Username?.ToLower() == loginModel.Email?.ToLower())
//                && u.Password == loginModel.Password);

//            if (foundUser == null)
//            {
//                // החזרת שגיאה מתאימה במידה ולא נמצאה התאמה
//                return NotFound(new { message = "שם משתמש או סיסמה שגויים" });
//            }

//            // החזרת המשתמש הממופה כעדות להצלחת החיבור
//            return Ok(mapper.Map<UsersDTO>(foundUser));
//        }
//    }

//    // 🎯 מחלקת עזר לקבלת הנתונים מטופס האנגולר
//    public class UsersLoginModel
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }
//    }
//}



using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cosmetics_Bll;
using Cosmetics_Dal.Models;
using CosmeticsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBll usersBLL;
        private readonly IMapper mapper;

        public UsersController(IUsersBll _usersBLL)
        {
            usersBLL = _usersBLL;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            mapper = config.CreateMapper();
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UsersDTO> Get()
        {
            List<Users> list = usersBLL.GetAllUsers();
            return mapper.Map<IEnumerable<UsersDTO>>(list);
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public UsersDTO Get(int id)
        {
            return mapper.Map<UsersDTO>(usersBLL.GetUsersById(id));
        }

        // PUT api/Users
        [HttpPut]
        public void Put([FromBody] UsersDTO updateUser)
        {
            Users user = mapper.Map<Users>(updateUser);
            usersBLL.UpdateUsers(user);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usersBLL.DeleteUser(id);
        }

        // POST: api/Users/register
        [HttpPost("register")]
        public ActionResult<object> Register([FromBody] UsersRegisterModel registerModel)
        {
            Console.WriteLine($"Register attempt for: {registerModel?.Email}");
            List<Users> list = usersBLL.GetAllUsers();

            bool isExists = list.Any(u =>
                u.Email?.ToLower() == registerModel.Email?.ToLower() ||
                u.Username?.ToLower() == registerModel.Username?.ToLower());

            if (isExists)
            {
                return BadRequest(new { message = "שם המשתמש או כתובת המייל כבר קיימים במערכת" });
            }

            Users newUser = new Users
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                Password = registerModel.Password,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
            };

            usersBLL.AddUsers(newUser);

            List<Users> updatedList = usersBLL.GetAllUsers();
            var createdUser = updatedList.FirstOrDefault(u => u.Email?.ToLower() == registerModel.Email?.ToLower());
            var userDto = mapper.Map<UsersDTO>(createdUser);

            return Ok(new
            {
                user = userDto,
                token = "mock-jwt-token-from-server"
            });
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public ActionResult<object> Login([FromBody] UsersLoginModel loginModel)
        {
            List<Users> list = usersBLL.GetAllUsers();

            var foundUser = list.FirstOrDefault(u =>
                (u.Email?.ToLower() == loginModel.Email?.ToLower() || u.Username?.ToLower() == loginModel.Email?.ToLower())
                && u.Password == loginModel.Password);

            if (foundUser == null)
            {
                return Unauthorized(new { message = "שם משתמש או סיסמה שגויים" });
            }

            var userDto = mapper.Map<UsersDTO>(foundUser);

            return Ok(new
            {
                user = userDto,
                token = "mock-jwt-token-from-server"
            });
        }
    }

    public class UsersLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UsersRegisterModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}