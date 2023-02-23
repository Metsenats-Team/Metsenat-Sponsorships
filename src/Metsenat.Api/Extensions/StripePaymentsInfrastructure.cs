using Metsenat.BLL.Interfaces;
using Metsenat.BLL.Services;
using Stripe;

namespace Metsenat.Api.Extensions;
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
