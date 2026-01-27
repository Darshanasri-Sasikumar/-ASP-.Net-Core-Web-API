namespace StudentPortal.Models
{
    public class CreateStudentdto
    {
        public required string Name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public required decimal Fees { get; set; }
        public string? Rollnumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
    }
}
