using Clf.Web.StorefrontApi1.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clf.Web.StorefrontApi1.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> logger;
    private ICustomerService customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        this.logger = logger;
        this.customerService = customerService;
    }

    [HttpGet(Name = "GetCustomer")]
    public IEnumerable<Domain.DomainModels.Customer> GetCustomer()
    {
        throw new NotImplementedException();
    }
}
