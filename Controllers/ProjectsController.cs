using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectsService.Models;

namespace ProjectsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsContext _context;

        public ProjectsController(ProjectsContext context)
        {
            _context = context;

            if (_context.Projects.Count() == 0)
            {
                // Create a new Project if the collection is empty.
                _context.Projects.Add(new Project { Name = "www.miketrout.dev", Description = "This website! It is hosted on GKE." });
                _context.Projects.Add(new Project { Name = "Software AG Natural Microservice PoC", Description = "A proof-of-concept for a Software AG Natural and Adabas microservice." });
                _context.SaveChanges();
            }
        }

        // GET: api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(long id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }
    }
}
