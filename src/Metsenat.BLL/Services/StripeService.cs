using Metsenat.BLL.Interfaces;
using Metsenat.Data.Entities.Stripe;
using Stripe;

namespace Metsenat.BLL.Services;
public class StripeService : IStripeService
{
    private readonly ChargeService _chargeService;
    private readonly CustomerService _customerService;
    private readonly TokenService _tokenService;

    public StripeService(
        ChargeService chargeService,
        CustomerService customerService,
        TokenService tokenService)
    {
        _chargeService = chargeService;
        _customerService = customerService;
        _tokenService = tokenService;
    }

    public async Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct)
    {
        //! here we are setting stripe token options
        var tokenOptions = new TokenCreateOptions
        {
            Card = new TokenCardOptions
            {
                Name = customer.Name,
                Number = customer.CreditCard!.CardNumber,
                ExpYear = customer.CreditCard.ExpirationYear,
                ExpMonth = customer.CreditCard.ExpirationMonth,
                Cvc = customer.CreditCard.Cvc
            }
        };
        //! creates new stripe token depending on tokenOptions that is passed
        var stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

        var customerOptions = new CustomerCreateOptions
        {
            Name = customer.Name,
            Email = customer.Email,
            Source = stripeToken.Id
        };
        //! here we are creating a cutomer at Stripe
        var createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

        //! finally we have to return customer that had been created at Stripe
        return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
    }

    public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
    {
        var paymentOptions = new ChargeCreateOptions
        {
            Customer = payment.CustomerId,
            ReceiptEmail = payment.ReceiptEmail,
            Description = payment.Description,
            Currency = payment.Currency,
            Amount = payment.Amount
        };

        var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

        return new StripePayment(
           createdPayment.CustomerId,
           createdPayment.ReceiptEmail,
           createdPayment.Description,
           createdPayment.Currency,
           createdPayment.Amount,
           createdPayment.Id);
    }
}
