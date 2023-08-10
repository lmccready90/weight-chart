using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace API.Controllers
{
    public class WeightLogsController : BasceController
    {
        private readonly DataContext _context;
        public WeightLogsController(DataContext context)
        {
            _context = context;    
        }

        [HttpGet] //api/weightLogs
        public async Task<ActionResult<List<Domain.WeightLog>>> GetWeightLogs()
        {
            return await _context.WeightLog.ToListAsync();
        }

        [HttpGet("{id}")] //api/weightLogs/id
        public async Task<ActionResult<Domain.WeightLog>> GetWeightLog(Guid id)
        {
            return await _context.WeightLog.FindAsync(id);
        }
    }
}