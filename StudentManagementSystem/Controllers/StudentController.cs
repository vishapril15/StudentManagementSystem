using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Common;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services.Interfaces;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(new ApiResponse<object>(true, "Data fetched successfully", data));
        }

        //  GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(new ApiResponse<object>(
                true,
                "Student fetched successfully",
                data
            ));
        }

        // ✅ ADD
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(false, "Invalid data", ModelState));

            await _service.AddAsync(dto);

            return StatusCode(201, new ApiResponse<object>(
                true,
                "Student created successfully",
                null
            ));
        }

        // ✅ UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(
                    false,
                    "Invalid data",
                    ModelState
                ));
            await _service.UpdateAsync(dto);
            return Ok(new ApiResponse<object>(
     true,
     "Student updated successfully",
     null
 ));
        }

        //  DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new ApiResponse<object>(
     true,
     "Student deleted successfully",
     null
 ));
        }
    }
}
