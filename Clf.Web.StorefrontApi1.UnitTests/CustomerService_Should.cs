using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Services;
using Microsoft.Extensions.Logging;

namespace Clf.Web.StorefrontApi1.UnitTests;

public class CustomerService_Should
{
    private readonly ILogger<CustomerService> logger;
    private readonly ICustomerRepository customerRepository;

    private readonly CustomerService customerService;

    public CustomerService_Should()
    {
        logger = Substitute.For<ILogger<CustomerService>>();
        customerRepository = Substitute.For<ICustomerRepository>();
        customerService = new CustomerService(logger, customerRepository );
    }

    [Fact]
    public void Get_a_customer()
    {
        // arrange
        // domain model
        int customerId = 1;
        string customerName = "a";
        Address billingAddress = new() { AddressType = AddressType.Billing, Address1 = "a1", Address2 = "a2", City = "Denver", State = "CO", Zip = "12345" };
        Address shippingAddress = new() { AddressType = AddressType.Shipping, Address1 = "s1", Address2 = "s2", City = "Mobile", State = "AL", Zip = "98765" };
        DateTime orderedOn1 = DateTime.Parse("2025-04-01");
        DateTime orderedOn2 = DateTime.Parse("2025-04-02");
        List<Order> orders = new()
        {
            new Order() { Number = 11, OrderedOn = orderedOn1, ShipTo = shippingAddress },
            new Order() { Number = 12, OrderedOn = orderedOn2, ShipTo = shippingAddress },
        };

        Customer customer = new()
        {
            Id = customerId,
            Name = customerName,
            BillingAddress = billingAddress,
            Orders = orders
        };

        // repository
        AddressDto billAddressDto = new()
        {
            AddressType = billingAddress.AddressType,
            Address1 = billingAddress.Address1,
            Address2 = billingAddress.Address2,
            City = billingAddress.City,
            State = billingAddress.State,
            Zip = billingAddress.Zip,
        };
        AddressDto shipAddressDto = new()
        {
            AddressType = shippingAddress.AddressType,
            Address1 = shippingAddress.Address1,
            Address2 = shippingAddress.Address2,
            City = shippingAddress.City,
            State = shippingAddress.State,
            Zip = shippingAddress.Zip,
        };
        List<OrderDto> orderDtos = new List<OrderDto>()
        {
            new(){Number = orders[0].Number, OrderedOn = orders[0].OrderedOn, ShipTo = shipAddressDto},
            new(){Number = orders[1].Number, OrderedOn = orders[1].OrderedOn, ShipTo = shipAddressDto},

        };
        CustomerDto customerDto = new()
        {
            Id = customerId,
            Name = customerName,
            BillingAddress = billAddressDto,
            Orders = orderDtos
        };

        customerRepository.GetCustomer(customerId).Returns(customerDto);

        // act
        var result = customerService.GetCustomer(customerId);

        // assert
        result.Should().BeEquivalentTo(customer);
    }
}