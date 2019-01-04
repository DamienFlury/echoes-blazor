using System;
using System.Collections.Generic;
using System.Text;

namespace Echoes.Shared.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ClassDto> Classes { get; set; }
        public ICollection<AssignmentDto> Assignments { get; set; }
    }
}
