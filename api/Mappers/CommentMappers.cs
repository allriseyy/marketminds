﻿using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto dto)
        {
            return new Comment
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedOn = DateTime.UtcNow,
                StockId = dto.StockId
            };
        }
    }
}
