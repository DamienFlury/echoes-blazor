using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Echoes.Server.Data;
using Echoes.Server.Data.Entities;
using Echoes.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Echoes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassesController(SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private IQueryable<ClassDto> GetAll() =>
            from cls in _context.Classes
            join sc in _context.StudentClasses on cls.Id equals sc.ClassId
            join student in _context.Students on sc.StudentId equals student.Id
            where student.User.UserName == User.Identity.Name
            select new ClassDto
            {
                Id = cls.Id,
                Name = cls.Name,
                Assignments = cls.Assignments.Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description
                }).ToArray()
            };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ClassDto>> Get() => Ok(GetAll());

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> Get(int id)
        {
            var cls = await GetAll().Include(c => c.Assignments).SingleOrDefaultAsync(c => c.Id == id);
            if (cls is null) return Unauthorized();
            return cls;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Class cls)
        {
            var student = await _context.Students.SingleOrDefaultAsync(std => std.User.UserName == User.Identity.Name);
            _context.StudentClasses.Add(new StudentClass { Student = student, Class = cls });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}