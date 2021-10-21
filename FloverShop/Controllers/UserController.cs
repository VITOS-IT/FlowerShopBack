using FloverShop.Models;
using FloverShop.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloverShop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService userService)
        {
            _service = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var userDTO = _service.Register(user);
            if (userDTO != null)
                return userDTO;
            return BadRequest("Not able to register");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Put([FromBody] UserDTO user)
        {
            var userDTO = _service.Login(user);
            if (userDTO != null)
                return Ok(userDTO);
            return BadRequest("Not able to login");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
