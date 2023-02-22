using Metsenat.BLL.DTOs;
using Metsenat.BLL.Interfaces;
using Metsenat.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Metsenat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly ISponsorService _sponsorService;
    public AdminsController(IStudentService studentService, ISponsorService sponsorService)
    {
        _studentService = studentService;
        _sponsorService = sponsorService;
    }

    [HttpPost("/students")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddStudents([FromBody] CreateStudentDto createStudentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _studentService.CreateStudentAsync(createStudentDto);
        return Ok();
    }

    [HttpGet("/students")]
    [ProducesResponseType(typeof(List<StudentView>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudents()
        => Ok(await _studentService.GetAllStudentsAsync());

    [HttpGet("/students/{studentId:int}")]
    [ProducesResponseType(typeof(StudentView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudentById(int studentId)
        => Ok(await _studentService.GetStudentByIdAsync(studentId));

    [HttpDelete("/students/{studentId:int}")]
    public async Task<IActionResult> DeleteStudent(int studentId)
        => Ok(await _studentService.DeleteStudentAsync(studentId));

    [HttpPut("/students/{studentId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateStudent(int studentId, UpdateStudentDto updateStudentDto)
        => Ok(await _studentService.UpdateStudentAsync(studentId, updateStudentDto));

    [HttpGet("/sponsors")]
    [ProducesResponseType(typeof(List<SponsorView>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSponsors()
        => Ok(await _sponsorService.GetSponsors());

    [HttpGet("/sponsors/{sponsorId:int}")]
    [ProducesResponseType(typeof(SponsorView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSponsorById(int sponsorId)
        => Ok(await _sponsorService.GetSponsorById(sponsorId));

    [HttpPut("/sponsors/{sponsorId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateSponsor(int sponsorId, UpdateSponsorDto updateSponsorDto)
        => Ok(await _sponsorService.UpdateSponsor(sponsorId, updateSponsorDto));

    [HttpDelete("/sponsors/{sponsorId:int}")]
    public async Task<IActionResult> DeleteSponsor(int sponsorId)
        => Ok(await _sponsorService.DeleteSponsor(sponsorId));
}
