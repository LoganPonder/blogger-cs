using System;
using blogger_cs.Services;
using blogger_cs.Models;
using Microsoft.AspNetCore.Mvc;


namespace blogger_cs.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class ProfileController : ControllerBase
    {
        // dont need to authorize... it may not be your account, you're just viewing someone elses profile, kick it to the account service
        private readonly AccountsService _service;

        public ProfileController(AccountsService service)
        {
            _service = service;
        }

        [HttpGet("{id")]
        public ActionResult<Blog> GetProfileById(int id)
        {
            try
            {
                Account account = _service.GetOrCreateAccount(id);
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}