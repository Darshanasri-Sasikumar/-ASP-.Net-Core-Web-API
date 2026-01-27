namespace StudentPortal.Models.Enitites
{
    public class StudentMarks
    {
        public Guid Id { get; set; }
        public int StudentId { get; set; }
        public int? Maths { get; set; }
        public int? Science { get; set; }
        public int? Social { get; set; }
        public int? English { get; set; }
        public int? Hindi { get; set; }

        public Student Student { get; set; }

        public bool IsDelete { get; set; } = false;

    }
}
