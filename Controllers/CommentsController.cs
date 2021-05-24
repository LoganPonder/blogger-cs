using blogger_cs.Services;
using Microsoft.AspNetCore.Mvc;
using blogger_cs.Models;
using System;

namespace blogger_cs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _service;
        public CommentsController(CommentsService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Comment> CreateComment([FromBody] Comment newComment)
        {
            try
            {
                Comment comment = _service.CreateComment(newComment);
                return Ok(comment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}