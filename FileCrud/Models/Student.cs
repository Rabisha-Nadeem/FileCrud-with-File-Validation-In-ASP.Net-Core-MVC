
using System.ComponentModel.DataAnnotations;

namespace FileCrud.Models
{
    public class Student
    {
        [Key]
        public Guid StdId { get; set; } = Guid.NewGuid();
        public string StdProfile { get; set; }
        public string StdName { get; set; }
        public int StdAge { get; set; }
        public string StdEmail { get; set; }
    }
}
