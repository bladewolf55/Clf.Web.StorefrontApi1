using Clf.Web.StorefrontApi1.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clf.Web.StorefrontApi1.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> logger;
    private ICustomerService customerService;

    public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
    {
        this.logger = logger;
        this.customerService = customerService;
    }

    [HttpGet]
    [Route("customerId")]
    [EndpointName("Customers_GetCustomer")]
    public ActionResult<Domain.DomainModels.Customer> GetCustomer(int customerId)
    {
        try
        {
            return customerService.GetCustomer(customerId);
        }
        catch (Exception ex) 
        {
            var msg = ex.GetBaseException().Message;
            logger.LogError(ex, msg);
            return Problem(msg);
        }
    }
}
