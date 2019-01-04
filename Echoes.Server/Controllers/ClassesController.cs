using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Echoes.Shared.Models;
using EchoesServer.Api.Data;
using EchoesServer.Api.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Echoes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassesController(SchoolContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Class>> Get()
        {
            return Ok(_context.Classes.Where(cls => cls.StudentClasses.Select(sc => sc.Student).Any(student => student.User.UserName == User.Identity.Name)).Select(cls => new ClassDto
            {
                Id = cls.Id,
                Name = cls.Name
            }));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(int id) =>
            await _context.Classes.Include(cls => cls.Assignments).SingleOrDefaultAsync(cls => cls.Id == id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] Class cls)
        {
            var student = await _context.Students.SingleOrDefaultAsync(std => std.User.UserName == User.Identity.Name);
            _context.StudentClasses.Add(new StudentClass { Student = student, Class = cls });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}