using Mapster;
using Metsenat.BLL.DTOs;
using Metsenat.BLL.Repositories;
using Metsenat.BLL.Services;
using Metsenat.Common.Exceptions;
using Metsenat.Data.Entities;
using Moq;

namespace Metsenat.Test;
public class StudentServiceTest
{
    private readonly StudentService _studentService;
    private readonly Mock<IStudentRepository> _mockRepo;

    public StudentServiceTest()
    {
        _mockRepo = new Mock<IStudentRepository>();
        _studentService = new StudentService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllStudentsAsync_Test()
    {
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FullName = "Amber Grey",
                PhoneNumber= "1234567890",
                UniversityName = "INHA University",
                StudentDegree = Data.Entities.Enums.EStudentDegree.Bachelors,
                AmountOfStudentsContract = 3000,
                DedicatedAmount = 1800
            },
            new Student
            {
                Id = 2,
                FullName = "Mr.Smith",
                PhoneNumber= "8934567890",
                UniversityName = "INHA University",
                StudentDegree = Data.Entities.Enums.EStudentDegree.Masters,
                AmountOfStudentsContract = 3200,
                DedicatedAmount = 2000
            },
        };

        _mockRepo.Setup(repo => repo.GetAllStudentsAsync()).ReturnsAsync(students);
        var result = await _studentService.GetAllStudentsAsync();
        Assert.NotNull(result);
        Assert.Equal(students.Count,result.Count);
    }

    [Fact]
    public async Task GetStudentByIdAsync_Test()
    {
        var student = new Student
        {
            Id = 1,
            FullName = "John Doe",
            PhoneNumber = "32412364545",
            UniversityName = "INHA University",
            StudentDegree = Data.Entities.Enums.EStudentDegree.Bachelors,
            AmountOfStudentsContract = 3000,
            DedicatedAmount = 2500
        };
        _mockRepo.Setup(repo => repo.GetStudentByIdAsync(1)).ReturnsAsync(student);
        var result = await _studentService.GetStudentByIdAsync(1);
        Assert.Equal(student.FullName, result.FullName);
    }

    [Fact]
    public async Task AddStudentAsync_Test()
    {
        var student = new Student
        {
            Id = 2,
            FullName = "Ashlie Green",
            PhoneNumber = "+3242367890",
            UniversityName = "IUBH University",
            StudentDegree = Data.Entities.Enums.EStudentDegree.Bachelors,
            AmountOfStudentsContract = 3000,
            DedicatedAmount = 1800
        };
        _mockRepo.Setup(repo => repo.AddStudentAsync(student)).ReturnsAsync(true);
        var createStudentDto = student.Adapt<CreateStudentDto>();
        var result = await _studentService.CreateStudentAsync(createStudentDto);
        
        Assert.NotNull(result);
        Assert.Contains(student.FullName, result.FullName);
    }
}