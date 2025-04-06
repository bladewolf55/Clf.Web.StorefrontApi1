using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Services;
using Microsoft.Extensions.Logging;
using Xunit;

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
        Customer customer = CustomerServiceTestData.CustomerModel;
        CustomerDto customerDto = CustomerServiceTestData.CustomerDtoModel;
        customerRepository.GetCustomer(customer.Id).Returns(customerDto);

        // act
        var result = customerService.GetCustomer(customer.Id);

        // assert
        result.Should().BeEquivalentTo(customer);
    }

    [Fact]
    public void Throw_if_customer_name_empty()
    {
        // arrange
        CustomerDto customerDto = CustomerServiceTestData.CustomerDtoModel;
        customerDto.Name = "";
        customerRepository.GetCustomer(customerDto.Id).Returns(customerDto);

        // act
        Action action = () => {customerService.GetCustomer(customerDto.Id);};

        // assert
        action.Should().Throw<Exception>()
            .WithMessage("*Customer isn't valid*")
            .WithMessage("*Name required*");
    }
}