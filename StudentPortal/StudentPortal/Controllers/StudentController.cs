using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Enitites;
using System.Reflection;

namespace StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private ApplicationDbContext dbContext;
        private readonly ApplicationDbContext _dbContext;


        public StudentController(ApplicationDbContext dbContext)
        {
            //this.dbContext = dbContext;
            _dbContext = dbContext;

        }


        //1.Used to Retrive data all data


        //[HttpGet]
        //public IActionResult GetAllStudents()
        //{
        //    var allStudents = _dbContext.Students.ToList();
        //    return Ok-(allStudents);
        //}


        //2.Used for search

        //[HttpGet]
        //public IActionResult GetAllStudents(string? name, string? email)
        //{
        //    var student = _dbContext.Students.AsQueryable();
        //    if (!string.IsNullOrWhiteSpace(name))
        //        student = student.Where(s => s.Name.Contains(name));

        //    if (!string.IsNullOrWhiteSpace(email))
        //        student = student.Where(s => s.email.Contains(email));

        //    return Ok(student.ToList());

        //}

        [HttpGet]
        public IActionResult GetAllStudent() 
        {
            var student = _dbContext.Students.
                Where(a => a.IsActive == true);
            return Ok(student);
        }

        [HttpGet("filter")]
        public IActionResult GetStudentsByFilter(
    string? name,
    string? email,
    bool? isActive,
    int page = 1,
    int pageSize = 10)
        {
            var students = _dbContext.Students.AsQueryable();

            // Filters
            if (!string.IsNullOrWhiteSpace(name))
                students = students.Where(s => s.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(email))
                students = students.Where(s => s.email.Contains(email));

            if (isActive.HasValue)
                students = students.Where(s => s.IsActive == isActive);

            // Total count BEFORE pagination
            var totalRecords = students.Count();

            // Pagination
            var pagedStudents = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Response
            return Ok(new
            {
                TotalRecords = totalRecords,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                message = "Data fetched Successfully",
                Data = pagedStudents,
               
            });
        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetStudentId(Guid id)
        {
            var getstudentid = _dbContext.Students.Find(id);
            if (getstudentid is null)
            {
                return NotFound();
            }

            return Ok(getstudentid);

        }

        [HttpPost]
        public IActionResult Addstudent(CreateStudentdto addstudentdto)
        {
            var StudentEntity = new Student()
            {
                Name = addstudentdto.Name,
                email = addstudentdto.email,
                phone = addstudentdto.phone,
                Fees = addstudentdto.Fees,
                Rollnumber = addstudentdto.Rollnumber,
                DateOfBirth = addstudentdto.DateOfBirth,
                Gender = addstudentdto.Gender,
                IsActive = true,
                CreatedAt = DateTime.UtcNow


            };

            _dbContext.Students.Add(StudentEntity);
            _dbContext.SaveChanges();
            return Ok(StudentEntity);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateStudent(Guid id , Updatestudentdto updatestudentdto)
        {
            var UpdateStudent = _dbContext.Students.Find(id);
            if(UpdateStudent is null)
            {
                return NotFound();
            }
            UpdateStudent.Name = updatestudentdto.Name;
            UpdateStudent.email = updatestudentdto.email;
            UpdateStudent.phone = updatestudentdto.phone;
            UpdateStudent.Fees = updatestudentdto.Fees;
            UpdateStudent.Rollnumber = updatestudentdto.Rollnumber;
            UpdateStudent.DateOfBirth = updatestudentdto.DateOfBirth;
            UpdateStudent.Gender = updatestudentdto.Gender;
            UpdateStudent.IsActive = true;
            UpdateStudent.CreatedAt = DateTime.UtcNow;

            _dbContext.SaveChanges();
            return Ok(UpdateStudent);



        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = _dbContext.Students.Find(id);
            if(student is null) {
                return NotFound();
            }
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();

            return Ok(student);

        }
        


    }
}
