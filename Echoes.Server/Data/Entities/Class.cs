using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Echoes.Server.Data.Entities
{
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}