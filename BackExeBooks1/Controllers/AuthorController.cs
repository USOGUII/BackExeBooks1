using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackExeBooks1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.SqlTypes;
using BackExeBooks1.Managers;


namespace BackExeBooks1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController: ControllerBase
    {
        private readonly booksContext _authorcontext;
        public AuthorsController(booksContext authorcontext)
        {
            _authorcontext = authorcontext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BecomeAuthorRequest request)
        {
            try
            {
               Author newAuthor = new Author()
                {
                    Familiya = request.Familiya,
                    Otchestvo = request.Otchestvo,
                    Name = request.Name,
                    procent = request.procent
                };

                var user = _authorcontext.Users.FirstOrDefault(x => x.UserId == request.UserId);
                newAuthor.UserId = user.UserId;

                _authorcontext.Authors.Add(newAuthor);
                await _authorcontext.SaveChangesAsync();
                return Ok(request);
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
            var authors = await _authorcontext.Authors.ToListAsync();
            return Ok(authors);
        }
    }
}
