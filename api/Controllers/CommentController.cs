using api.Data;
using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ApplicationDBContext context, ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDtos = comments.Select(c => c.ToCommentDto());
            return Ok(commentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentDto)
        {
            if (commentDto == null) return BadRequest("Stock data is required.");
            var stockExists = await _stockRepo.GetByIdAsync(commentDto.StockId);
            if (stockExists == null)
                return BadRequest($"No stock found with ID {commentDto.StockId}.");
            var comment = commentDto.ToCommentFromCreateDto();
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCommentRequestDto updateDto)
        {
            var existingComment = await _commentRepo.GetByIdAsync(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            // Optional: validate stock ID
            var stock = await _stockRepo.GetByIdAsync(updateDto.StockId);
            if (stock == null)
            {
                return BadRequest($"Stock with ID {updateDto.StockId} does not exist.");
            }

            existingComment.Title = updateDto.Title;
            existingComment.Content = updateDto.Content;
            existingComment.StockId = updateDto.StockId;

            await _commentRepo.UpdateAsync(existingComment);
            return Ok(existingComment.ToCommentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingComment = await _commentRepo.GetByIdAsync(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            await _commentRepo.DeleteAsync(existingComment);
            return NoContent();
        }
    }
}
