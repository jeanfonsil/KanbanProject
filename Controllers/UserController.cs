using KanbanProjectFinal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KanbanProjectFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();
        private static int id = 1;
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            user.Id = id++;
            users.Add(user);
            return CreatedAtAction(nameof(GetUserId), new { Id = user.Id }, user);
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }
        [HttpGet("{id}")]

        public IActionResult GetUserId(int id)
        {
            User user = users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

    }
}