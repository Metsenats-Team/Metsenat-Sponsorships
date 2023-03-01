using Metsenat.BLL.FilterDtos.Enum;
using Metsenat.Common.Models;

namespace Metsenat.BLL.FilterDtos;

public class StudentFilterDto : PaginationParams
{
    public string? UniversityName { get; set; }
    public EStudentFilter? StudentFilter { get; set; }
}