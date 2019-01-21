using System.Collections.Generic;
using Echoes.Server.Data;
using Echoes.Server.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Echoes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context) => _context = context;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get() => 
            Ok(_context.Students);

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id) => _context.Students.Find(id);
    }
}