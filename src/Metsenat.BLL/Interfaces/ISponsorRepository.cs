using Metsenat.BLL.DTOs;
using Metsenat.BLL.ViewModels;
using Metsenat.Data.Entities;
using Metsenat.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metsenat.BLL.Interfaces;
public interface ISponsorRepository
{
    Task<List<SponsorView>> GetSponsorsAsync();
    Task<Sponsor> GetSponsorByIdAsync(int sponsorId);
    Task<bool> CreateSponsorAsync (CreateSponsorDto createsponsorDto);
    Task<Sponsor> UpdateSponsorAsync(int sponsorId, UpdateSponsorDto updateSponsorDto);
    Task<bool> DeleteSponsorAsync(int sponsorId);

}
