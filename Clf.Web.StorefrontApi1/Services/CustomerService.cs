using Clf.Web.StorefrontApi1.Domain.DataMapping;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Domain.Services;

namespace Clf.Web.StorefrontApi1.Services;
public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> logger;
    private readonly ICustomerRepository customerRepository;

    public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository)
    {
        this.logger = logger;
        this.customerRepository = customerRepository;
    }

    public Customer GetCustomer(int id)
    {
        var customerDto = customerRepository.GetCustomer(id);
        var billingAddressDto = customerDto.BillingAddress;
        var ordersDto = customerDto.Orders;

        // mapping
        var customer = customerDto.ToDomain();

        if (!customer.IsValid())
        {
            var errors = String.Join(Environment.NewLine, customer.Validate());
            var msg = $"Customer isn't valid: {errors}";
            logger.LogError($"{nameof(CustomerService)} {nameof(GetCustomer)} {msg}");
            throw new Exception(msg);
        }

        return customer;
    }
}
