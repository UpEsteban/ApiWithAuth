using Microsoft.AspNetCore.Mvc;
using PoocCore.Domain.DTO.Dtos;
using PoocCore.Domain.Services;
using System.Collections.Generic;

namespace PoocCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<BookDto>> Get() =>
            _bookService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<BookDto> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<BookDto> Create(BookDto book)
        {
            var bookDto = _bookService.Create(book);
            return CreatedAtRoute("GetBook", new { id = bookDto.Id.ToString() }, bookDto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BookDto bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}
