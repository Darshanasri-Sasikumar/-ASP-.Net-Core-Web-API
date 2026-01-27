using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Enitites
{
    public class Student
    {
        public Guid Id { get; set; }
        [MinLength (3)]
        public required string Name { get; set; }   
        [EmailAddress]
        public string? email { get; set; }
        [Required]
        public string? phone { get; set; }

        [Range(1,double.MaxValue)]
        public required decimal Fees { get; set; }
        public string? Rollnumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
