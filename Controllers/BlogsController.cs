using System.Collections.Generic;
using blogger_cs.Services;
using Microsoft.AspNetCore.Mvc;
using blogger_cs.Models;
using System;

namespace blogger_cs.Controllers
{
        [ApiController]
        [Route("api/[controller]")]

        public class BlogsController : ControllerBase
        {
            private readonly BlogsService _service;

            public BlogsController(BlogsService service)
            {
                _service = service;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Blog>> GetAllBlogs()
            {
                try
                {
                    IEnumerable<Blog> blogs = _service.GetAllBlogs();
                    return Ok(blogs);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpGet("{id")]
            public ActionResult<Blog> GetBlogById(int id)
            {
                try
                {
                    Blog blog = _service.GetBlogById(id);
                    return Ok(blog);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPost]
            public ActionResult<Blog> CreateBlog([FromBody] Blog newBlog)
            {
                try{
                    Blog blog = _service.CreateBlog(newBlog);
                    return Ok(blog);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPut("{id")]
            public ActionResult<Blog> EditBlog(int id, [FromBody] Blog edit)
            {
                try 
                {
                    edit.Id = id;
                    Blog edited = _service.EditBlog(edit);
                    return Ok(edited);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id}")]
            public ActionResult<Blog> DeleteBlog(int id)
            {
                try 
                {
                    _service.DeleteBlog(id);
                    return Ok("Successfully Deleted");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
}