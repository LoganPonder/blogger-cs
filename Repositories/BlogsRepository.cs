using System;
using System.Collections.Generic;
using System.Data;
using blogger_cs.Models;
using Dapper;

namespace blogger_cs.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;
        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Blog> GetAllBlogs()
        {
            string sql = "SELECT * FROM blogs";
            return _db.Query<Blog>(sql);
        }

        internal Blog GetBlogById(int id)
        {
            string sql = "SELECT * FROM blogs WHERE id = @id";
            return _db.QueryFirstOrDefault<Blog>(sql, new { id });
        }

        internal Blog CreateBlog(Blog newBlog)
        {
            string sql = @"
            INSERT INTO blogs
            (title, body, imgurl, published, creatorid)
            VALUES
            (@Title, @Body, @ImgUrl, @Published, @CreatorID);
            SELECT LAST_INSERT_ID()";

            newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
            return newBlog;
        }

        internal bool EditBlog(Blog original)
        {
            string sql = @"
            UPDATE blogs
            SET
                title = @Title,
                body = @Body,
                imgurl = ImgUrl,
                published = @Published,
                creatorid =  @CreatorId
            WHERE id = @Id
            ";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        internal void DeleteBlog(int id)
        {
            string sql = "DELETE FROM blogs WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            // return affectedRows == 1;
        }
    }
}