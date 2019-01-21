namespace Echoes.Server.Data.Entities
{
    public class Invitation
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}