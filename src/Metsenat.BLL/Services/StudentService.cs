using Mapster;
using Metsenat.BLL.DTOs;
using Metsenat.Common.Exceptions;
using Metsenat.BLL.Interfaces;
using Metsenat.BLL.ViewModels;
using Metsenat.Data.Entities;
using Metsenat.BLL.FilterDtos;
using Metsenat.Data.Entities.Enums;

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
    public async Task<List<StudentView>> GetAllStudentsAsync(StudentFilterDto sortingFilterDto)
    {
        var existingStudents = await _studentRepository.GetAllStudentsAsync();

        if (sortingFilterDto.StudentFilter is not null)
            existingStudents.Where(s => s.StudentDegree.Equals(EStudentDegree.Bachelors)).ToList();
        else
            existingStudents.Where(s => s.StudentDegree.Equals(EStudentDegree.Masters)).ToList();

        if (sortingFilterDto.UniversityName is not null)
            existingStudents = (existingStudents.Where(s =>
            s.UniversityName == sortingFilterDto.UniversityName)).ToList();

        return existingStudents.Adapt<List<StudentView>>();
    }
}
