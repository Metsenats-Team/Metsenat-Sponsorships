using Mapster;
using Metsenat.BLL.DTOs;
using Metsenat.BLL.Interfaces;
using Metsenat.BLL.ViewModels;
using Metsenat.Common.Exceptions;
using Metsenat.Data.Data;
using Metsenat.Data.Entities;

namespace Metsenat.BLL.Services;

public class SponsorService : ISponsorService
{
    private readonly AppDbContext _context;
    private readonly ISponsorRepository _repository;
    public SponsorService(AppDbContext context, ISponsorRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<SponsorView> CreateSponsorAsync(CreateSponsorDto createSponsorDto)
    {    
       var result = int.TryParse(createSponsorDto.Phone, out var phoneNumber);
        if (!result) throw new Exception("phone value is not number");
        await _repository.CreateSponsorAsync(createSponsorDto);
        return createSponsorDto.Adapt<SponsorView>();
    }

    public async Task<bool> DeleteSponsorAsync(int sponsorId)
    {
        var sponsor = await _repository.GetSponsorByIdAsync(sponsorId);
        if (sponsor is null) return false;
        return await _repository.DeleteSponsorAsync(sponsorId);
    }

    public async Task<List<SponsorView>> GetSponsorsAsync()
    {
        return await _repository.GetSponsorsAsync();
    }

    public async Task<SponsorView> GetSponsorByIdAsync(int sponsorId)
    {
        var sponsor = await _repository.GetSponsorByIdAsync(sponsorId);
        if (sponsor is null)
            throw new NotFoundException<Sponsor>();
        return sponsor.Adapt<SponsorView>();
    }

    public async Task<SponsorView> UpdateSponsorAsync(int sponsorId, UpdateSponsorDto updateSponsorDto)
    {
        var sponsor = await _repository.GetSponsorByIdAsync(sponsorId);
        if (sponsor is null)
            throw new Exception();
        var currentsponsor = await _repository.UpdateSponsorAsync(sponsorId, updateSponsorDto);
        return currentsponsor.Adapt<SponsorView>();
    }
}
