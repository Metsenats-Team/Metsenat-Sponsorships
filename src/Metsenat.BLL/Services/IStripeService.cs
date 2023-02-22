using Metsenat.BLL.DTOs;

namespace Metsenat.BLL.Services;
public interface IStripeService
{
    Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
    Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
}
