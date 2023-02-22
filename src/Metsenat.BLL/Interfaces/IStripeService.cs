using Metsenat.Data.Entities.Stripe;

namespace Metsenat.BLL.Interfaces;
public interface IStripeService
{
    Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
    Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
}
