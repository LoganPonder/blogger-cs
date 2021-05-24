using System;
using System.Data;
using blogger_cs.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace blogger_cs.Repositories
{
    public class CommentsRepository
    {
        private readonly IDbConnection _db;

        public CommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Comment CreateComment(Comment newComment)
        {
            string sql = @"
            INSERT INTO comments
            (id, creatorid, body, blog)
            VALUES
            (@Id, @CreatorId, @Body, @Blog);
            SELECT LAST_INSERT_ID()";

            newComment.Id = _db.ExecuteScalar<int>(sql, newComment);
            return newComment;
        }
    }
}