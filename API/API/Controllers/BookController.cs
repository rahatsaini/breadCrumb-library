using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery] string? search = null, [FromQuery] bool? isAvailable = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _bookService.GetBooksAsync(
                search, isAvailable, page, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                var createdBoook = await _bookService.CreateBookAsync(book);
                return CreatedAtAction(nameof(GetBook), new { id = createdBoook.Id }, createdBoook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id)
        {
            try
            {
                var updatedBook = await _bookService.ToggleAvailabiltyBookAsync(id);
                if (updatedBook == null)
                {
                    return NotFound();
                }
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
