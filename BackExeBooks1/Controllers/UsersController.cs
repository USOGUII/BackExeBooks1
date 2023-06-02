using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackExeBooks1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.SqlTypes;

namespace Pain.Suffer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext _userscontext;
        public UsersController(UsersContext usercontext)
        {
            _userscontext = usercontext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users person)
        {
            try
            {
                _userscontext.Users.Add(person);
                _userscontext.SaveChanges();
                await _userscontext.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return Ok(msg);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userscontext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
