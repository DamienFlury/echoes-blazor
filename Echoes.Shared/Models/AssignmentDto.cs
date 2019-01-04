using System;
using System.Collections.Generic;
using System.Text;

namespace Echoes.Shared.Models
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<StudentDto> Students { get; set; }
        public int ClassId { get; set; }
        public ClassDto Class { get; set; }
    }
}
