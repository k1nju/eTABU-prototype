using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTABU.Server;
using eTABU.Server.Entity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace eTABU.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/login")]
        public async Task<ActionResult<User>> Login(string login, string password)
        {
            List<User> users = _context.Users.Where(x => x.Login == login && x.Password == password).ToList();
            if(users.Count > 0)
            {
                return Ok(users.First());
            }

            return BadRequest();
        }
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/register")]
        public async Task<ActionResult<User>> Register(string login, string password)
        {
            _context.Users.Add(new User(login, password));
            await _context.SaveChangesAsync();
            return Ok(_context.Users.Where(x=>x.Login == login && x.Password == password).First());
        }
    }
}
