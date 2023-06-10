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
    public class PurchaseListAController : ControllerBase
    {
        private readonly booksContext _purchasecontext;
        public PurchaseListAController(booksContext purchasecontext)
        {
            _purchasecontext = purchasecontext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FillPurchaseListA request)
        {
            try
            {
                PurchaseListA purchaselist = new PurchaseListA();
                _purchasecontext.PurchaseListAs.Add(purchaselist);
                var users = _purchasecontext.Users.FirstOrDefault(x => x.UserId == request.UserId);
                purchaselist.UserId = users.UserId;
                var books = _purchasecontext.AuthorBooks.FirstOrDefault(x => x.AuthorBookId == request.AuthorBookId);
                purchaselist.AuthorBookId = books.AuthorBookId;
                await _purchasecontext.SaveChangesAsync();
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
            var books = await _purchasecontext.PurchaseListAs.ToListAsync();
            return Ok(books);
        }
    }
}
