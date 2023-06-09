﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackExeBooks1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackExeBooks1.Managers;

namespace BackExeBooksex
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly booksContext _bookscontext;
        public BooksController(booksContext usercontext)
        {
            _bookscontext = usercontext;
        }

        [HttpGet]
        [Route("GetList/{userId:int}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var books = _bookscontext.Books
                .Join(_bookscontext.PurchaseLists,
                u => u.BookId,
                c => c.BookId,
                (u, c) => new
                {
                    UserId = c.UserId,
                    BookId = c.BookId,
                    BookAuthor = u.BookAuthor,
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
        public async Task<IActionResult> Post([FromBody] CreateBookRequest request)
        {
            try
            {
                Book newBook = new Book()
                {
                    BookAuthor = request.BookAuthor,
                    BookName = request.BookName,
                    BookDate = request.BookDate,
                    BookDescription = request.BookDescription,
                    BookGenre = request.BookGenre,
                    BookLenght = request.BookLenght,
                    BookPrice = request.BookPrice,
                    imgUrl = request.imgUrl,
                    BookUrl = request.BookUrl
                };

                var publishingHouse = _bookscontext.PublishingHouses.FirstOrDefault(x => x.PublishingHouseId == request.PublishingHouseId);
                newBook.PublishingHouseId = publishingHouse.PublishingHouseId;

                _bookscontext.Books.Add(newBook);
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
            var books = await _bookscontext.Books.ToListAsync();
            return Ok(books);
        }
    }
}
