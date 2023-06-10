using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackExeBooks1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.SqlTypes;
using BackExeBooks1.Managers;

namespace BackExeBooksex
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly booksContext _userscontext;
        public UsersController(booksContext usercontext)
        {
            _userscontext = usercontext;
        }

        [HttpPut]
        [Route("role")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRole roleupdate)
        {
            var user = await _userscontext.Users.FirstOrDefaultAsync(x => x.UserId == roleupdate.UserId);

            if (user != null)
            {
                user.role = roleupdate.role;
                await _userscontext.SaveChangesAsync();
                return Ok(roleupdate);
            }
            else
            {
                return Ok(roleupdate);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserMoney moneyupdate)
        {
            var user = await _userscontext.Users.FirstOrDefaultAsync(x => x.UserId == moneyupdate.UserId);

            if (user != null)
            {
                user.Money += moneyupdate.Money;
                await _userscontext.SaveChangesAsync();
                return Ok(moneyupdate);
            }
            else
            {
                return Ok(moneyupdate);
            }
            }

        [HttpPost]
        public async Task<IActionResult> Post(UsersCreate person)
        {
            try
            {
                var users1 = _userscontext.Users.Where(p => p.email == person.email);
                if (users1.Any())
                {
                    throw new Exception("Пользователь с такой почтой уже существует");
                }
                var users = _userscontext.Users.Where(p => p.UserLogin == person.UserLogin);
                if (users.Any())
                {
                    throw new Exception("Пользователь с таким логином уже существует");
                }
                _userscontext.Users.Add(person);
                await _userscontext.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return BadRequest(msg);
            }
        }
        record class Error(string Message);

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userscontext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
