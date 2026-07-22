namespace FileCrud.Models
{
    public class StudentViewModel
    {
        public Guid StdId { get; set; } 
        public IFormFile StdProfile { get; set; }
        public string StdName { get; set; }
        public int StdAge { get; set; }
        public string StdEmail { get; set; }
    }
}
