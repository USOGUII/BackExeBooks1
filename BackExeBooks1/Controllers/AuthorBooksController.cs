using BackExeBooks1.Managers;
using BackExeBooks1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackExeBooks1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBooksController: ControllerBase
    {
        private readonly booksContext _bookscontext;
        public AuthorBooksController(booksContext usercontext)
        {
            _bookscontext = usercontext;
        }

        [HttpGet]
        [Route("GetList/{userId:int}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var books = _bookscontext.AuthorBooks
                .Join(_bookscontext.PurchaseListAs,
                u => u.AuthorBookId,
                c => c.AuthorBookId,
                (u, c) => new
                {
                    UserId = c.UserId,
                    authBookId = c.AuthorBookId,
                    authName = u.authName,
                    authFamiliya = u.authFamiliya,
                    authOtchestvo = u.authOtchestvo,
                    BookName = u.BookName,
                    BookDate = u.BookDate,
                    BookDescription = u.BookDescription,
                    BookGenre = u.BookGenre,
                    BookLenght = u.BookLenght,
                    BookPrice = u.BookPrice,
                    imgUrl = u.imgUrl,
                    BookUrl = u.BookUrl
                }
                ).Where(x => x.UserId == userId);
            await _bookscontext.SaveChangesAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuthorBook request)
        {
            try
            {
                AuthorBook newBook = new AuthorBook()
                {
                    authName = request.authName,
                    authFamiliya = request.authFamiliya,
                    authOtchestvo = request.authOtchestvo,
                    BookName = request.BookName,
                    BookDate = request.BookDate,
                    BookDescription = request.BookDescription,
                    BookGenre = request.BookGenre,
                    BookLenght = request.BookLenght,
                    BookPrice = request.BookPrice,
                    imgUrl = request.imgUrl,
                    BookUrl = request.BookUrl
                };

                var authorbook = _bookscontext.Authors.FirstOrDefault(x => x.AuthorId == request.AuthorId);
                newBook.AuthorId = authorbook.AuthorId;

                _bookscontext.AuthorBooks.Add(newBook);
                await _bookscontext.SaveChangesAsync();
                return Ok();
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
            var books = await _bookscontext.AuthorBooks.ToListAsync();
            return Ok(books);
        }
    }
}
