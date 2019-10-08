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
                _context.Projects.Add(new Project
                {
                    Id = 1,
                    Name = "www.miketrout.dev",
                    Description = @"This website!
                        <br>
                        The site is written in plain HTML, CSS and JavaScript, deliberately
                        avoiding the use of frameworks. It is built into a container image,
                        using the Nginx Docker image as a base. The running container serves
                        the site using Nginx. The site is deployed as a Kubernetes deployment on
                        Google Kubernetes Engine and exposed as a service. A GKE ingress deals
                        with HTTPS, SSL termination and managed certificates from LetsEncrypt.
                        The site repository is
                        <a href=""https://github.com/miketrout/www.miketrout.dev"">here</a>.
                        Pushes to master are built and deployed to GKE by Travis CI.
                        <br>
                        The Experience, Projects and Skills resources are retrieved from an
                        API hosted at
                        <a href=""https://api.miketrout.dev"">api.miketrout.dev</a>. The
                        loading times are deliberately exagerated to visually emphasise the
                        fact that they are being retrieved from an API. Ambassador is deployed
                        to GKE and used as a simple API gateway. Ambassador was chosen because
                        of its simplicity and because it is Kubernetes native."
                });
                _context.Projects.Add(new Project
                {
                    Id = 2,
                    Name = "Software AG Natural Microservice PoC",
                    Description = "A proof-of-concept for a Software AG Natural and Adabas microservice."
                });
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
