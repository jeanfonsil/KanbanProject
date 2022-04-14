using AutoMapper;
using KanbanProjectFinal.Data;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KanbanProjectFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintController : ControllerBase
    {
        private KanbanContext _context;
        private IMapper _mapper;

        public SprintController(KanbanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSprint([FromBody] CreateSprintDto sprintDto)
        {
            Sprint sprint = _mapper.Map<Sprint>(sprintDto);

            _context.Sprints.Add(sprint);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSprintId), new { Id = sprint.Id }, sprint);
        }
        [HttpGet]
        public IActionResult GetSprints()
        {
            return Ok(_context.Sprints);
        }
        [HttpGet("{id}")]

        public IActionResult GetSprintId(int id)
        {
            Sprint sprint = _context.Sprints.FirstOrDefault(sprint => sprint.Id == id);
            if (sprint != null)
            {
                ReadSprintDto sprintDto = _mapper.Map<ReadSprintDto>(sprint);
                return Ok(sprintDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSprint(int id)
        {
            Sprint sprint = _context.Sprints.FirstOrDefault(sprint => sprint.Id == id);
            if (sprint == null)
            {
                return NotFound();
            }
            _context.Sprints.Remove(sprint);
            _context.SaveChanges();
            return NoContent();
        }

    }
}