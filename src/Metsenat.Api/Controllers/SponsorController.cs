using Metsenat.BLL.DTOs;
using Metsenat.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Metsenat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SponsorController : ControllerBase
{
    private readonly ISponsorService sponsorService;

    public SponsorController(ISponsorService sponsorService)
    {
        this.sponsorService = sponsorService;
    }

    [HttpPost("/sponsors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddSponsor(CreateSponsorDto createSponsor)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await sponsorService.CreateSponsor(createSponsor);
        return Ok();
    }
}
