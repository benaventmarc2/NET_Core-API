using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityDB.DataAccess;
using UniversityDB.Helpers;
using UniversityDB.Models;
using UniversityDB.Models.DataModels;

namespace UniversityDB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;
        public AccountsController(JwtSettings jwtSettings, UniversityDBContext context)
        {
            this._jwtSettings = jwtSettings;
            this._context = context;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "benaventmarc@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "marc@gmail.com",
                Name = "User1",
                Password = "1234"
            }           
        };

        [HttpPost]
        public IActionResult GetToken(UserLoggin userLogin)
        {
            try
            {
                var Token = new UserTokens();

                // Search a user in context with LINQ
                var searchUser = (from user in _context.Users
                                 where user.Name == userLogin.UserName
                                 && user.Password == userLogin.Password
                                 select user).FirstOrDefault();                
                
                if (searchUser != null)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                } 
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {

                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
