using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Services;
using Microsoft.Extensions.Logging;

namespace Clf.Web.StorefrontApi1.UnitTests;

public class CustomerService_Should
{
    private readonly ILogger<CustomerService> logger;
    private readonly ICustomerRepository customerRepository;
    private readonly IOrderRepository orderRepository;
    private readonly IAddressRepository addressRepository;
    private readonly CustomerService customerService;

    public CustomerService_Should()
    {
        logger = Substitute.For<ILogger<CustomerService>>();
        customerRepository = Substitute.For<ICustomerRepository>();
        addressRepository = Substitute.For<IAddressRepository>();
        orderRepository = Substitute.For<IOrderRepository>();
        customerService = new CustomerService(logger, customerRepository, addressRepository, orderRepository );
    }

    [Fact]
    public void Get_a_customer()
    {
        // arrange
        // domain model
        int customerId = 1;
        string customerName = "a";
        Domain.DomainModels.Address billingAddress = new() { Address1 = "a1", Address2 = "a2", City = "Denver", State = "CO", Zip = "12345" };
        Domain.DomainModels.Address shippingAddress = new() { Address1 = "s1", Address2 = "s2", City = "Mobile", State = "AL", Zip = "98765" };
        DateTime orderedOn1 = DateTime.Parse("2025-04-01");
        DateTime orderedOn2 = DateTime.Parse("2025-04-02");
        List<Order> orders = new()
        {
            new Domain.DomainModels.Order() { Number = 11, OrderedOn = orderedOn1 },
            new Domain.DomainModels.Order() { Number = 12, OrderedOn = orderedOn2 },
        };

        Domain.DomainModels.Customer customer = new Domain.DomainModels.Customer(
            id: customerId,
            name: customerName,
            billingAddress: billingAddress,
            orders: orders
        );

        // repository
        customerRepository.GetCustomer(customerId).Returns(customer as Domain.DataTransfer.CustomerDto);
        addressRepository.GetCustomerAddresses(customerId).Returns(new List<Domain.DataTransfer.AddressDto>()
        { 
            billingAddress as Domain.DataTransfer.AddressDto,
            shippingAddress as Domain.DataTransfer.AddressDto,
        });
        orderRepository.GetCustomerOrders(customerId).Returns(orders);        

        // act
        var result = customerService.GetCustomer(customerId);

        // assert
        result.Should().BeEquivalentTo(customer);
    }
}