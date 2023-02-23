using Metsenat.BLL.Interfaces;
using Metsenat.BLL.Repositories;
using Metsenat.BLL.Services;
using Metsenat.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Metsenat.Api.Extensions;
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

    public static void AddRequiredServicesAndRepos(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IStudentService, StudentService>();
        builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();
        builder.Services.AddScoped<ISponsorService, SponsorService>();
        builder.Services.AddScoped<IStripeService, StripeService>();
    }
}
