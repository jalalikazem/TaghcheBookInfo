using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaghcheBookInfo.Application;

namespace TaghcheBookInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly GetBookHandler _getBookHandler;
        public BookController(GetBookHandler getBookHandler)
        {
            _getBookHandler = getBookHandler;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _getBookHandler.GetBook(id));
        }
    }
}
