﻿using AutoMapper;
using KanbanProjectFinal.Data;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KanbanProjectFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private KanbanContext _context;
        private IMapper _mapper;

        public UserController(KanbanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

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
                UserDto userDto = _mapper.Map<UserDto>(user);
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            _mapper.Map(userDto, user);
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