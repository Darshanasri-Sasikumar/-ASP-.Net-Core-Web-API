using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Enitites;

namespace StudentPortal.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentMarksController:ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public StudentMarksController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet("Filter")]
        public IActionResult GetStudentMarksByFilter(int? Maths,int? Scince,int? Social, int? Hindi )
        {
            var studentMarks = _db.StudentMarks.AsQueryable();

            if (Maths.HasValue)
                studentMarks = studentMarks.Where(s => s.Maths == Maths);

            if (Scince.HasValue)
                studentMarks = studentMarks.Where(s => s.Science == Scince);

            if (Social.HasValue)
                studentMarks = studentMarks.Where(s => s.Social == Social);

            if (Hindi.HasValue)
                studentMarks = studentMarks.Where(s => s.Hindi == Hindi);

            return Ok(studentMarks.ToList());
        }

        [HttpGet]
        public IActionResult GetAllStudentMarks()
        {
            var studentMark = _db.StudentMarks.ToList();
            return Ok(new {});
        }


        //[HttpPost]
        //public IActionResult CreatData(CreateStudentMarksdto dto)
        //{
        //    if (!_db.Students.Any(a => a.Id == dto.StudentId))
        //        return BadRequest("Invalid data");

        //    var studentmarks = new StudentMarks()
        //    {
        //        StudentId = dto.StudentId,
        //        Maths = dto.Maths,
        //        Science = dto.Science,
        //        Social = dto.Social,
        //        English = dto.English,
        //        Hindi = dto.Hindi
        //    };
        //    _db.StudentMarks.Add(studentmarks);
        //    _db.SaveChanges();
        //    return Ok(studentmarks);
        //}

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult updatestudentMarks(Guid id,UpdateStudentMarksdto dto)
        {
            var studentmarksupdate = _db.StudentMarks.Find(id);
            if(studentmarksupdate is null)
            {
                return NotFound();
            }

            studentmarksupdate.Maths = dto.Maths;
            studentmarksupdate.Science = dto.Science;
            studentmarksupdate.Social = dto.Social;
            studentmarksupdate.English = dto.English;
            studentmarksupdate.Hindi = dto.Hindi;

            _db.SaveChanges();
            return Ok(studentmarksupdate);


        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getById(Guid id)
        {
            var studentid = _db.StudentMarks.Find(id);
            return Ok(studentid);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        
        public IActionResult deletebyid(Guid id)
        {
            var studentdelete = _db.StudentMarks.Find(id);
            if(studentdelete is null)
            {
                return NotFound();
            }
            _db.StudentMarks.Remove(studentdelete);
            _db.SaveChanges();

            return Ok(studentdelete);
        }
        




    }
}
