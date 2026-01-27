namespace StudentPortal.Models
{
    public class CreateStudentMarksdto
    {
        public int StudentId { get; set; }
        public int? Maths { get; set; }
        public int? Science { get; set; }
        public int? Social { get; set; }
        public int? English { get; set; }
        public int? Hindi { get; set; }
    }
}
