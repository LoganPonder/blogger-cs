using System;
using System.Collections.Generic;
using blogger_cs.Models;
using blogger_cs.Repositories;

namespace blogger_cs.Services
{
    public class BlogsService
    {

        private readonly BlogsRepository _repo;

        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Blog> GetAllBlogs()
        {
            return _repo.GetAllBlogs();
        }

        internal Blog GetBlogById(int id)
        {
            Blog blog = _repo.GetBlogById(id);
            if(blog == null){
                throw new Exception("Invalid ID");
            }
            return blog;
        }

        internal Blog CreateBlog(Blog newBlog)
        {
            Blog blog = _repo.CreateBlog(newBlog);
            return blog;
        }

        internal Blog EditBlog(Blog edit)
        {
            Blog original = GetBlogById(edit.Id);
            original.Title = edit.Title.Length > 0 ? edit.Title : original.Title;
            original.Body = edit.Body.Length > 0 ? edit.Body : original.Body;
            original.ImgUrl = edit.ImgUrl.Length > 0 ? edit.ImgUrl : original.ImgUrl;
            original.Published = edit.Published;
            original.CreatorId = edit.CreatorId;
            if(_repo.EditBlog(original))
            {
                return original;
            }
            throw new Exception("Unable to edit, try again.");
        }

        internal void DeleteBlog(int id)
        {
            // GetBlogById(id);
            _repo.DeleteBlog(id);
        }
    }
}