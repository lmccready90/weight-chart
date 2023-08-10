using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace API.Controllers
{
    public class UnitsController : BasceController
    {
        private readonly DataContext _context;
        public UnitsController(DataContext context)
        {            
            _context = context; 
        }

        [HttpGet] //api/units
        public async Task<ActionResult<List<Domain.Unit>>> GetUnits()
        {
            return await _context.Unit.ToListAsync();
        }

        [HttpGet("{id}")] //api/units/id
        public async Task<ActionResult<Domain.Unit>> GetUnit(int id)
        {
            return await _context.Unit.FindAsync(id);
        }
    }     
}