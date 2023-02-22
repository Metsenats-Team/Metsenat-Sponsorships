using Metsenat.BLL.Interfaces;
using Metsenat.BLL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Metsenat.Common.Extenstions;
public static class StripePaymentsInfrastructure
{
    public static void AddStripePaymentsInfrastructure(this WebApplicationBuilder builder)
    {
        StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("StripeSettings:SecretKey");

        builder.Services.AddScoped<CustomerService>()
            .AddScoped<ChargeService>()
            .AddScoped<TokenService>()
            .AddScoped<IStripeService, StripeService>();
    }
}
