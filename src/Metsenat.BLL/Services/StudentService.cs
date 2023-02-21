using Mapster;
using Metsenat.BLL.DTOs;
using Metsenat.BLL.Repositories;
using Metsenat.BLL.ViewModels;
using Metsenat.Common.Exceptions;
using Metsenat.Data.Entities;

namespace Metsenat.BLL.Services;
public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
        => _studentRepository = studentRepository;

    public async Task<StudentView> CreateStudentAsync(CreateStudentDto createStudentDto)
    {
        await _studentRepository.AddStudentAsync(createStudentDto.Adapt<Student>());
        return createStudentDto.Adapt<StudentView>();
    }
    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);
        if (student is null)
            return false;
        return await _studentRepository.DeleteStudentAsync(student);
    }
    public async Task<StudentView> GetStudentByIdAsync(int studentId)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);
        if (student is null)
            throw new NotFoundException<Student>();
        return student.Adapt<StudentView>();
    }
    public async Task<StudentView> UpdateStudentAsync(int studentId, UpdateStudentDto updateStudentDto)
    {
        var student = (await GetStudentByIdAsync(studentId)).Adapt<Student>();
        student = updateStudentDto.Adapt<Student>();
        await _studentRepository.UpdateStudentAsync(student);
        return student.Adapt<StudentView>();
    }
    public async Task<List<StudentView>> GetAllStudentsAsync()
        => (await _studentRepository.GetAllStudentsAsync()).Adapt<List<StudentView>>();
}
