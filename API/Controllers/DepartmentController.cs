using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepartmentController : MainApiController
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentRepository.GetAllAsync());
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok(await _departmentRepository.GetAAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {
            return Ok(await _departmentRepository.InsertAsync(department));
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code,Department department)
        {
            return Ok(await _departmentRepository.UpdateAsync(code, department));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok(await _departmentRepository.DeleteAsync(code));
        }
    }

    // public static class DepartmentStatic
    // {
    //     private static List<Department> AllDepartment { get; set; } = new List<Department>();
    //
    //     public static Department InsertDepartment(Department department)
    //     {
    //         AllDepartment.Add(department);
    //         return department;
    //     }
    //
    //     public static List<Department> GetAllDepartment()
    //     {
    //         return AllDepartment;
    //     }
    //
    //     public static Department GetADepartment(string code)
    //     {
    //         return AllDepartment.FirstOrDefault(x => x.Code == code);
    //     }
    //
    //     public static Department UpdateDepartment(string code, Department department)
    //     {
    //         Department result = new Department();
    //
    //         foreach (var aDepartment in AllDepartment)
    //         {
    //             if(code == aDepartment.Code)
    //             {
    //                 aDepartment.Name = department.Name;
    //                 result = aDepartment;
    //             }
    //         }
    //
    //         return result;
    //     }
    //
    //     public static Department DeleteDepartment(string code)
    //     {
    //         var department = AllDepartment.FirstOrDefault(x => x.Code == code);
    //         AllDepartment = AllDepartment.Where(x => x.Code != department.Code).ToList();
    //
    //         return department;
    //     }
    // }
}
