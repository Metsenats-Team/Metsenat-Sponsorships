using Metsenat.BLL.Interfaces;
using Metsenat.Data.Entities.Stripe;
using Microsoft.AspNetCore.Mvc;

namespace Metsenat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IStripeService _stripeService;
    public PaymentsController(IStripeService stripeService)
        => _stripeService = stripeService;
    
    [HttpPost]
    public async Task<ActionResult<StripeCustomer>> AddStripeCustomer(
           [FromBody] AddStripeCustomer customer, CancellationToken ct)
    {
        StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(customer, ct);

        return Ok(createdCustomer);
    }

    [HttpPost("payment/add")]
    public async Task<ActionResult<StripePayment>> AddStripePayment(
        [FromBody] AddStripePayment payment, CancellationToken ct)
    {
        StripePayment createdPayment = await _stripeService
            .AddStripePaymentAsync(payment, ct);

        return Ok(createdPayment);
    }
}
