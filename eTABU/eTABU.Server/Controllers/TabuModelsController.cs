using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTABU.Server;
using eTABU.Server.Entity;

namespace eTABU.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabuModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public TabuModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TabuModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabuModel>>> GetWords()
        {
            return await _context.Words.ToListAsync();
        }
    }
}
