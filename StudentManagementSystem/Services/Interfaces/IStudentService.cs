using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Interfaces
{
    public interface IStudentService
    {

        Task<IEnumerable<StudentResponseDto>> GetAllAsync();
        Task<StudentResponseDto> GetByIdAsync(int id);
        Task AddAsync(CreateStudentDto dto);
        Task UpdateAsync(UpdateStudentDto dto);
        Task DeleteAsync(int id);
    }
}
