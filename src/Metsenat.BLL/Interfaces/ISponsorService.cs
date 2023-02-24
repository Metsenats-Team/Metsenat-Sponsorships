using Metsenat.BLL.DTOs;
using Metsenat.BLL.ViewModels;

namespace Metsenat.BLL.Interfaces
{
    public interface ISponsorService
    {
        Task<List<SponsorView>> GetSponsorsAsync();
        Task<SponsorView> GetSponsorByIdAsync(int sponsorId);
        Task<SponsorView> CreateSponsorAsync(CreateSponsorDto createSponsor);
        Task<SponsorView> UpdateSponsorAsync(int sponsorId, UpdateSponsorDto updateSponsorDto);
        Task<bool> DeleteSponsorAsync(int sponsorId);
    }
}
