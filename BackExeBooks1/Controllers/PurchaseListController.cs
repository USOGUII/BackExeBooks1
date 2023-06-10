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
        public class PurchaseListController: ControllerBase
        {
            private readonly booksContext _purchasecontext; 
            public PurchaseListController(booksContext purchasecontext)
            {
                _purchasecontext = purchasecontext;
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] FillPurchaseList request)
                {
                try
                {
                    PurchaseList purchaselist = new PurchaseList();
                    _purchasecontext.PurchaseLists.Add(purchaselist);
                    var users = _purchasecontext.Users.FirstOrDefault(x => x.UserId == request.UserId);
                    purchaselist.UserId = users.UserId;
                    var books = _purchasecontext.Books.FirstOrDefault(x => x.BookId == request.BookId);
                    purchaselist.BookId = books.BookId;
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
                var books = await _purchasecontext.PurchaseLists.ToListAsync();
                return Ok(books);
            }
        }
}
