using Serilog;

namespace Metsenat.Api.Extensions;
public static class LoggerExtensions
{
    public static void AddSerilogConfig(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.PostgreSQL(connectionString, "exceptions")
            .CreateLogger();
        builder.Logging.AddSerilog(logger);
    }
}
