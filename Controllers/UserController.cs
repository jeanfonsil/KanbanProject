using KanbanProjectFinal.Data;
using KanbanProjectFinal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KanbanProjectFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private KanbanContext _context;

        public UserController(KanbanContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserId), new { Id = user.Id }, user);
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users);
        }
        [HttpGet("{id}")]

        public IActionResult GetUserId(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User newUser)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            user.Name = newUser.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

    }
}