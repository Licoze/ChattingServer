using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChattingServer.ControllerModels;
using ChattingServer.DAL.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChattingServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UserController : ControllerBase
    {
        private UserManager<User> _userManager;
        public UserController(UserManager<User> userManager) {
            _userManager = userManager;
        }
        [HttpPut]
        public async Task<ActionResult<string>> AddUser([FromBody]UserCreationModel model) {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null) return StatusCode(409,"Already exist");
            user = new User {
                UserName = model.UserName,
                Email = model.Email
            };
            var result=await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return StatusCode(200,"Successfully Added");
            }
            else {
                var errorResult=new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errorResult.Append(error.Description);
                    errorResult.Append("\n");

                }
                return StatusCode(400, errorResult);
            }
            
        }
    }
}