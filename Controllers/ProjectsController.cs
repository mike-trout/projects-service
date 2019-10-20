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
                    Description = @"<p>This site is written in plain HTML, CSS and JavaScript,
deliberately avoiding the use of frameworks. The responsive layout is designed for both large and
small screen resolutions. It is also printable. The site is built into a container image, using
the Nginx Docker image as the base. It is deployed as a Kubernetes deployment on Google Kubernetes
Engine and exposed as a service. A GKE ingress deals with HTTPS, TLS termination and managed
certificates from Let's Encrypt. The site is versioned on
<a href=""https://github.com/mike-trout/www.miketrout.dev""
rel=""noopener noreferrer"" target=""_blank"">GitHub</a>. Pushes to master are built
and deployed to GKE by Travis CI.</p>

<p>The Experience, Projects and Skills resources are retrieved from an API hosted at
<a href=""https://api.miketrout.dev""
rel=""noopener noreferrer"" target=""_blank"">https://api.miketrout.dev</a>. The loading times are
deliberately exaggerated in JavaScript and CSS to visually emphasise the fact that they are being
retrieved from an API. <a href=""https://www.getambassador.io""
rel=""noopener noreferrer"" target=""_blank"">Ambassador</a> is deployed to GKE
and used as a simple API gateway, exposed by a GKE ingress with managed certificates. Ambassador
was chosen because of its simplicity and because it is Kubernetes native. The
<a href=""https://api.miketrout.dev/experience/""
rel=""noopener noreferrer"" target=""_blank"">/experience/</a>,
<a href=""https://api.miketrout.dev/projects/""
rel=""noopener noreferrer"" target=""_blank"">/projects/</a> and
<a href=""https://api.miketrout.dev/skills/""
rel=""noopener noreferrer"" target=""_blank"">/skills/</a> paths are routed to the backend
experience, projects and skills microservices. The repository for the API gateway is also on
<a href=""https://github.com/mike-trout/api.miketrout.dev""
rel=""noopener noreferrer"" target=""_blank"">GitHub</a> and also automatically
deployed by Travis CI.</p>

<p>The
<a href=""https://github.com/mike-trout/experience-service""
rel=""noopener noreferrer"" target=""_blank"">experience microservice</a>
is written in JavaScript and runs on Node.js. The
<a href=""https://github.com/mike-trout/projects-service""
rel=""noopener noreferrer"" target=""_blank"">projects microservice</a>
that returns this text is written in C# and uses the ASP.NET Core framework. The
<a href=""https://github.com/mike-trout/skills-service""
rel=""noopener noreferrer"" target=""_blank"">skills microservice</a>
is written in Go and runs as a single binary. All the services are containerised and deployed as
Kubernetes deployments to GKE. NodePort services exposes them to the Ambassador resource mappings.
Travis CI pipelines automate the build, test and deploy processes.</p>

<p>Of course, the highly available, horizontally scalable architecture is massively over
engineered for the amount of traffic that this site receives. But that's kind of the point!</p>"
                });
                _context.Projects.Add(new Project
                {
                    Id = 2,
                    Name = "Software AG Natural Microservice PoC",
                    Description = @"<p>This project is a proof-of-concept to demonstrate that
business logic tied up in legacy Software AG Natural code can be exposed as containerised
microservices deployed to Kubernetes. It consists of two parts: the
<a href=""https://github.com/mike-trout/employees-service""
rel=""noopener noreferrer"" target=""_blank"">backend microservice</a> that runs Natural code
accessing a containerised Software AG Adabas database; and a
<a href=""https://github.com/mike-trout/employees-app""
rel=""noopener noreferrer"" target=""_blank"">frontend React UI</a>.</p>

<p>The backend service and frontend UI are deployed to GKE and exposed by the same GKE ingress
used by www.miketrout.dev by specifying additional forwarding rules. The application URL is
<a href=""https://www.miketrout.dev/employees-app""
rel=""noopener noreferrer"" target=""_blank"">https://www.miketrout.dev/employees-app</a>. As it
is only intended as a proof of concept, don't expect a responsive layout and do expect some bugs!
</p>"
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
