using Serilog;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Interfaces;
using StudentManagementSystem.Services.Interfaces;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            Log.Information("Fetching all students");

            var students = await _repo.GetAllAsync();

            if (!students.Any())
                Log.Warning("No students found");

            return students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Course = s.Course
            });
        }

        public async Task<StudentResponseDto> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);

            if (s == null)
            {
                Log.Warning("Student not found with id {Id}", id);
                throw new KeyNotFoundException("Student not found");
            }

            return new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Course = s.Course
            };
        }

        public async Task AddAsync(CreateStudentDto dto)
        {
            Log.Information("Adding student with email {Email}", dto.Email);
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.UtcNow
            };

            await _repo.AddAsync(student);
        }

        public async Task UpdateAsync(UpdateStudentDto dto)
        {
            Log.Information("Updating student with id {Id}", dto.Id);

            var existing = await _repo.GetByIdAsync(dto.Id);

            if (existing == null)
            {
                Log.Warning("Student not found for update with id {Id}", dto.Id);
                throw new KeyNotFoundException("Student not found");
            }

            existing.Name = dto.Name;
            existing.Email = dto.Email;
            existing.Age = dto.Age;
            existing.Course = dto.Course;

            await _repo.UpdateAsync(existing);
        }


        public async Task DeleteAsync(int id)
        {
            Log.Information("Deleting student with id {Id}", id);

            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
            {
                Log.Warning("Student not found for delete with id {Id}", id);
                throw new KeyNotFoundException("Student not found");
            }

            await _repo.DeleteAsync(id);
        }
    }
}
