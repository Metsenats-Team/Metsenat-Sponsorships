using Metsenat.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metsenat.Common.Extenstions;
public static class RequiredServiceExtensions
{
    public static void AddAppDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(optiosns =>
        {
            optiosns.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseLazyLoadingProxies();
        });
    }
}
