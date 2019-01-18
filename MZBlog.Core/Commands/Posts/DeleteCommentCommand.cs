﻿using Microsoft.Data.Sqlite;
using MediatR;
using Dapper;
using Dapper.Extensions;
using MZBlog.Core.Entities;

namespace MZBlog.Core.Commands.Posts
{
    public class DeleteCommentCommand : IRequest<CommandResult>
    {
        public string CommentId { get; set; }
    }

    public class DeleteCommentCommandInvoker : RequestHandler<DeleteCommentCommand, CommandResult>
    {
        private readonly SqliteConnection _conn;

        public DeleteCommentCommandInvoker(SqliteConnection conn)
        {
            _conn = conn;
        }

        protected override CommandResult Handle(DeleteCommentCommand cmd)
        {
            _conn.Execute("delete from BlogComment where Id =@id", new { id = cmd.CommentId });
            return CommandResult.SuccessResult;
        }
    }
}