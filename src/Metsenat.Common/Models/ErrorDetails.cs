using System.Text.Json;

namespace Metsenat.Common.Models;
public class ErrorDetails
{
    public string ErrorMessage { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
