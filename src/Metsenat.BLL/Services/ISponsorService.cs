using Metsenat.BLL.DTOs;
using Metsenat.BLL.ViewModels;

namespace Metsenat.BLL.Services
{
    public interface ISponsorService
    {
        Task<List<SponsorView>> GetSponsors();
        Task<SponsorView> GetSponsorById(int sponsorId);
        Task<SponsorView> CreateSponsor(CreateSponsorDto createSponsor);
        Task<SponsorView> UpdateSponsor(int sponsorId, UpdateSponsorDto updateSponsorDto);
        Task<bool> DeleteSponsor(int sponsorId);
    }
}
