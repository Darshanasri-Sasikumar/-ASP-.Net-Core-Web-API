namespace StudentPortal.Models.Enitites
{
    public class StudentCourse
    {
        public Guid Id { get; set; }
        public int StudentId { get; set; }

        public string? CourseName { get; set; }
        public DateTime? Duration { get; set; }
        public double? Fees { get; set; }

    }



         


}


