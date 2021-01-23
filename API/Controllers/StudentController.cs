using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StudentController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentState.GetAllStudent());
        }

        [HttpGet("{name}")]
        public IActionResult GetA(string name)
        {
            return Ok(StudentState.GetAStudent(name));
        }

        [HttpPost]
        public IActionResult Insert([FromForm] Student student)
        {
            return Ok(StudentState.InsertStudent(student));
        }

        [HttpPut("{name}")]
        public IActionResult Update(string name, Student student)
        {
            return Ok(StudentState.UpdateStudent(name, student));
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            return Ok(StudentState.DeleteStudent(name));
        }
    }

    public static class StudentState
    {
        private static List<Student> AllStudent { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            AllStudent.Add(student);
            return student;
        }

        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Student GetAStudent(string name)
        {
            return AllStudent.FirstOrDefault(x => x.Name == name);
        }

        public static Student UpdateStudent(string name, Student student)
        {
            var result = new Student();

            foreach (var aStudent in AllStudent.Where(aStudent => name == aStudent.Name))
            {
                aStudent.Name = student.Name;
                result = aStudent;
            }

            return result;
        }

        public static Student DeleteStudent(string name)
        {
            var student = AllStudent.FirstOrDefault(x => x.Name == name);
            AllStudent = AllStudent.Where(x => student != null && x.Name != student.Name).ToList();

            return student;
        }
    }
}
