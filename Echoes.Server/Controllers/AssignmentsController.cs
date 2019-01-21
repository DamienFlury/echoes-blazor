using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Echoes.Server.Data;
using Echoes.Server.Data.Entities;
using Echoes.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Echoes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AssignmentsController(SchoolContext context) => _context = context;

        private IQueryable<AssignmentDto> GetAll() =>
            from assignment in _context.Assignments
            join cls in _context.Classes on assignment.ClassId equals cls.Id
            join sc in _context.StudentClasses on cls.Id equals sc.ClassId
            join student in _context.Students on sc.StudentId equals student.Id
            where student.User.UserName == User.Identity.Name
            select new AssignmentDto
            {
                Id = assignment.Id,
                Title = assignment.Title,
                Description = assignment.Description,
                DueTo = assignment.DueTo
            };


        private IQueryable<AssignmentDto> GetActiveAssignments() =>
            from assignment in GetAll()
            where assignment.DueTo >= DateTime.Now
            orderby assignment.DueTo
            select assignment;

        private IQueryable<AssignmentDto> GetActiveDoneAssignments() =>
            from assignment in GetActiveAssignments()
            join sa in _context.StudentAssignments on assignment.Id equals sa.AssignmentId
            join student in _context.Students on sa.StudentId equals student.Id
            select assignment;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<AssignmentDto>> Get() => Ok(GetAll());

        [HttpGet("Active")]
        public ActionResult<IEnumerable<AssignmentDto>> GetActive()
        {
            return Ok(GetActiveAssignments());
        }

        [HttpGet("Active/Done")]
        public ActionResult<IEnumerable<AssignmentDto>> GetDone() => Ok(GetActiveDoneAssignments());

        [HttpGet("Active/NotDone")]
        public ActionResult<IEnumerable<AssignmentDto>> GetNotDone() =>
            Ok(GetActiveAssignments().Except(GetActiveDoneAssignments()));

        [HttpGet("Inactive")]
        public ActionResult<IEnumerable<AssignmentDto>> GetInactive()
        {
            var assignments = from assignment in GetAll()
                where assignment.DueTo < DateTime.Now
                orderby assignment.DueTo
                select assignment;

            return Ok(assignments);
        }

        // GET api/values/5        
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAsync(int id)
        {
            var assignment = await GetAll().SingleOrDefaultAsync(a => a.Id == id);
            if (assignment is null) return Unauthorized();
            return assignment;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentDto assignmentDto)
        {
            // var classId = assignment.ClassId;
            // if (classId == 0) return BadRequest ();
            // var student = await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);
            // if(!student.StudentClasses.Any(sc => sc.StudentId == student.Id && sc.ClassId == classId)) return BadRequest();
            var studentId =
                (await _context.Students.SingleOrDefaultAsync(student => student.User.UserName == User.Identity.Name))?.Id;

            if (studentId is null) return BadRequest();

            var assignment = new Assignment
            {
                Title = assignmentDto.Title,
                Description = assignmentDto.Description,
                ClassId = assignmentDto.ClassId,
                DueTo = assignmentDto.DueTo,
                StudentId = studentId.Value
            };

            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student =
                await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);

            if (student is null) return BadRequest();

            var assignment = await _context.Assignments.SingleOrDefaultAsync(a => a.Id == id);

            if (assignment is null) return BadRequest();

            if (assignment.StudentId != student.Id) return BadRequest();

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AssignmentDto assignmentDto)
        {
            
            if (assignmentDto is null) return BadRequest();
            
            if (id != assignmentDto.Id) return BadRequest();
            var assignment = await _context.Assignments.FindAsync(assignmentDto.Id);
            assignment.Title = assignmentDto.Title;
            assignment.Description = assignmentDto.Description;

            var student =
                await _context.Students.SingleOrDefaultAsync(stud => stud.User.UserName == User.Identity.Name);

            if (student is null) return BadRequest();

            if (assignment.StudentId != student.Id) return BadRequest();


            _context.Entry(assignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPost("Done")]
        public async Task<IActionResult> SetToDone([FromBody] int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();
            var assignment = await _context.Assignments.SingleOrDefaultAsync(a => a.Id == id);
            if (assignment is null) return BadRequest();
            await _context.StudentAssignments.AddAsync(new StudentAssignment
            {
                StudentId = student.Id,
                AssignmentId = id
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}