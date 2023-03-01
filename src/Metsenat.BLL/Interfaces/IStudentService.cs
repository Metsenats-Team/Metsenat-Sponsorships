using Metsenat.BLL.DTOs;
using Metsenat.BLL.FilterDtos;
using Metsenat.BLL.ViewModels;
using Metsenat.Common.Models;

namespace Metsenat.BLL.Interfaces;
public interface IStudentService
{
    Task<StudentView> CreateStudentAsync(CreateStudentDto createStudentDto);
    Task<StudentView> GetStudentByIdAsync(int studentId);
    Task<List<StudentView>> GetAllStudentsAsync(StudentFilterDto studentFilterDto);
    Task<bool> DeleteStudentAsync(int studentId);
    Task<StudentView> UpdateStudentAsync(int studentId, UpdateStudentDto updateStudentDto);
}
