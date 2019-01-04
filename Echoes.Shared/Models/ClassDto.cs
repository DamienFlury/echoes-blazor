using System;
using System.Collections.Generic;
using System.Text;

namespace Echoes.Shared.Models
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentDto> Students { get; set; }
        public ICollection<AssignmentDto> Assignments { get; set; }
    }
}
