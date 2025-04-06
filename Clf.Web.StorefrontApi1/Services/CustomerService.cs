using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.Services;

namespace Clf.Web.StorefrontApi1.Services;

public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> logger;
    private readonly ICustomerRepository customerRepository;

    public CustomerService(ILogger<CustomerService> logger, 
        ICustomerRepository customerRepository)
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
        var customer = new Customer()
        {
            Id = customerDto.Id,
            Name = customerDto.Name
        };
        if (billingAddressDto != null)
        {
            customer.BillingAddress = new Address()
            {
                AddressType = billingAddressDto.AddressType,
                Address1 = billingAddressDto.Address1,
                Address2 = billingAddressDto.Address2,
                City = billingAddressDto.City,
                State = billingAddressDto.State,
                Zip = billingAddressDto.Zip
            };
        }
        customer.Orders = ordersDto.Select(dto => new Order()
        {
            Number = dto.Number,
            OrderedOn = dto.OrderedOn,
            ShipTo = dto.ShipTo == null ? null : new Address()
            {
                AddressType = dto.ShipTo.AddressType,
                Address1 = dto.ShipTo.Address1,
                Address2 = dto.ShipTo.Address2,
                City = dto.ShipTo.City,
                State = dto.ShipTo.State,
                Zip = dto.ShipTo.Zip
            },
        }).ToList();

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
