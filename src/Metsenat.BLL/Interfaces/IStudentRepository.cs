using Metsenat.BLL.DTOs;
using Metsenat.Data.Entities;

namespace Metsenat.BLL.Interfaces;
public interface IStudentRepository
{
    Task<bool> AddStudentAsync(Student createStudentDto);
    Task<Student> GetStudentByIdAsync(int studentId);
    Task<List<Student>> GetAllStudentsAsync();
    Task<bool> DeleteStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Student updateStudentDto);
}
