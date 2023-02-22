using System.ComponentModel.DataAnnotations;

namespace Metsenat.BLL.DTOs;
public class CreateSponsorDto
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public string? OrganizationName { get; set; }
}
