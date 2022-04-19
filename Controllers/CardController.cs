using AutoMapper;
using KanbanProjectFinal.Data;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using KanbanProjectFinal.Models;

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

            for (int j = 0; j < 3; j++)
            {
                PercentTask[j] = (NumTask[j] / SumTask) * 100;
            }            

            return Ok(PercentTask);
        }

        [HttpGet]
        [Route("TaskProgressPerUser")]
        public IActionResult TaskProgressPerUser()
        {
            var cards = _context.Cards;           

            var teste = cards
                .GroupBy(card => card.UserId)
                .Select(Group => new { Group.Key, TotalEstimate = Group.Sum(card => card.Estimate) });

            int cont = 0;
            int x = 0;

            foreach (var a in teste)
            {
                cont++;
            }
            int[] KeyVector = new int[cont];
            foreach (var a in teste)
            {
                Console.WriteLine("Key: {0}", a.Key);
                Console.WriteLine("Total Estimate: {0}", a.TotalEstimate);
                KeyVector[x] = a.Key;
                x++;
            }

            Console.WriteLine("Cont {0}", KeyVector);
            Console.WriteLine("Cont {0}", cont);
            decimal[,] NumTaskUser = new decimal[cont,3];
            for (int i = 0; i < cont; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NumTaskUser[i,j] = (decimal)cards
                        .Where(card => (int)card.Status == j)
                        .Where(card => (int)card.UserId == KeyVector[i])
                        .Select(card => card.Estimate).Sum();
                }
            }

            decimal[][] ShowRow = new decimal[cont][];
            decimal[][] PercentTaskUser = new decimal[cont][];
            decimal[] SumTaskUser = new decimal[cont];


            for (int k = 0; k < cont; k++)
            {
                ShowRow[k] = Matrix.GetRow(NumTaskUser, k);
                SumTaskUser[k] = ShowRow[k].Sum();
                PercentTaskUser[k] = Matrix.GetPercentage(NumTaskUser, k, SumTaskUser[k]);
            }         


            //PercentTaskUser[k][0] = ShowRow[k][0] / SumTaskUser[k];

            return Ok(PercentTaskUser);
        }                
    }
}