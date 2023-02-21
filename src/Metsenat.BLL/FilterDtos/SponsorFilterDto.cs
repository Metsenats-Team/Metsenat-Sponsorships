using Metsenat.BLL.FilterDtos.Enum;

namespace Metsenat.BLL.FilterDtos;

public class SponsorFilterDto
{
    public decimal? Amount { get; set; }
    public ESponsorFilter? SponsorFilter { get; set; }
    public DateTime? CreatedDate { get; set; }
}