using AutoMapper;
using KanbanProjectFinal.Data;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KanbanProjectFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private KanbanContext _context;
        private IMapper _mapper;

        public CardController(KanbanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCard([FromBody] CreateCardDto cardDto)
        {
            Card card = _mapper.Map<Card>(cardDto);

            _context.Cards.Add(card);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCardId), new { Id = card.Id }, card);
        }
        [HttpGet]
        public IActionResult GetCards()
        {
            return Ok(_context.Cards);
        }
        [HttpGet("{id}")]

        public IActionResult GetCardId(int id)
        {
            Card card = _context.Cards.Include("User").Include("Sprint").FirstOrDefault(card => card.Id == id);
            if (card != null)
            {
                ReadCardDto cardDto = _mapper.Map<ReadCardDto>(card);
                return Ok(cardDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCard(int id, [FromBody] UpdateCardDto cardDto)
        {
            Card card = _context.Cards.FirstOrDefault(card => card.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            _mapper.Map(cardDto, card);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            Card card = _context.Cards.FirstOrDefault(card => card.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            _context.Cards.Remove(card);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet]
        [Route("TaskProgress")]
        public IActionResult TaskProgress()
        {
            decimal[] NumTask = new decimal[3];
            decimal[] PercentTask = new decimal[3];
            var cards = _context.Cards;

            decimal SumTask = 0;

            for (int i = 0; i < 3; i++)
            {
                NumTask[i] = (decimal)cards
                .Where(card => (int)card.Status == i)
                .Select(card => card.Estimate).Sum();
                SumTask = SumTask + NumTask[i];
            }

            PercentTask[0] = (NumTask[0] / SumTask) * 100;
            PercentTask[1] = (NumTask[1] / SumTask) * 100;
            PercentTask[2] = (NumTask[2] / SumTask) * 100;

            return Ok(PercentTask);
        }        
    }
}