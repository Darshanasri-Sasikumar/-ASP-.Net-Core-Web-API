using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Enitites;

namespace StudentPortal.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class StudentCourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentCourseController(ApplicationDbContext db)
        {
            _context = db;

        }

        [HttpGet]
        public IActionResult getCourseDetails()
        {
            var CourseDetails = _context.StudentCourse.ToList();
            return Ok(new
            {
                Data = CourseDetails,
                Message = "Data fetched Sucessfully",
                Status = 200

            }
               );


        }

        [HttpPost]
        public IActionResult CreateCourseDetail(CreateCourseDetailsdto dto)
        {
            var coursedetail = new StudentCourse()
            {
                StudentId = dto.StudentId,
                CourseName = dto.CourseName,
                Duration = dto.Duration,
                Fees = dto.Fees,

            };
            _context.StudentCourse.Add(coursedetail);
            _context.SaveChanges();
            return Ok(new
            {
                CourseDetail = coursedetail,
                Message = "Data Stored Sucessfully",
                Status = 200
            });





        }
    }
}