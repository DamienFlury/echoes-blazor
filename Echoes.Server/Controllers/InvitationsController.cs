using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Echoes.Server.Data;
using Echoes.Server.Data.Entities;
using Echoes.Shared;
using Echoes.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Echoes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvitationsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public InvitationsController(SchoolContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> InviteAsync(InvitationByEmail invitation)
        {
            var invitedStudent = _context.Students.SingleOrDefault(student => student.User.Email == invitation.Email);
            if (invitedStudent is null) return BadRequest();

            var studentId = invitedStudent.Id;

            _context.Invitations.Add(new Invitation
            {
                ClassId = invitation.ClassId,
                StudentId = studentId
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClassDto>> Get()
        {
            var student = _context.Students.SingleOrDefault(stud => stud.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();

            var invitations = from invitation in _context.Invitations
                where invitation.StudentId == student.Id
                select new ClassDto
                {
                    Id= invitation.Class.Id,
                    Name = invitation.Class.Name
                };

            return Ok(invitations);
        }

        [HttpGet("accept/{id}")]
        public ActionResult<IEnumerable<ClassDto>> Accept(int id)
        {
            var student = _context.Students.SingleOrDefault(stud => stud.User.UserName == User.Identity.Name);
            if (student is null) return BadRequest();

            _context.StudentClasses.Add(new StudentClass
            {
                StudentId = student.Id,
                ClassId = id
            });

            var invitationToRemove = _context.Invitations.SingleOrDefault(inv => inv.ClassId == id && inv.StudentId == student.Id);
            if (invitationToRemove is null) return BadRequest();
            _context.Invitations.Remove(invitationToRemove);

            _context.SaveChanges();
            return Get();
        }
    }
}