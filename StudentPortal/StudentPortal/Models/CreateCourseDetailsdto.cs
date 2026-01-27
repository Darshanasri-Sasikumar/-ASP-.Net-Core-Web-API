using StudentPortal.Models.Enitites;

namespace StudentPortal.Models
{
    public class CreateCourseDetailsdto
    {
        
        public int StudentId { get; set; }

        public string? CourseName { get; set; }
        public DateTime? Duration { get; set; }
        public double? Fees { get; set; }

       
    }
}
