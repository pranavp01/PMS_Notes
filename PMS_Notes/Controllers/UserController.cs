using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using PMS_Notes.Models;
using System.Threading.Tasks;
using PMS_Notes.Interface;

namespace PMS_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService = new UserService();
        [HttpPost]
        [Route("ChangePassword")]
        public ActionResult<int> ChangePassword(User user)
        {
            try
            {
                var result = _userService.ChangePassword(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
