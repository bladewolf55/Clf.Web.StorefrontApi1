using Clf.Web.StorefrontApi1.Domain.DataMapping;

namespace Clf.Web.StorefrontApi1.UnitTests;
public class DataMapping_Should
{
    [Fact]
    public void Map_customer_dto_to_domain()
    {
        // act
        var domain = CustomerServiceTestData.CustomerDto.ToDomain();

        // assert
        domain.Should().BeEquivalentTo(CustomerServiceTestData.Customer);
    }

    [Fact]
    public void Map_customer_domain_to_dto()
    {
        // act
        var dto = CustomerServiceTestData.Customer.ToDto();

        // assert
        dto.Should().BeEquivalentTo(CustomerServiceTestData.CustomerDto);
    }

    [Fact]
    public void Map_address_dto_to_domain()
    {
        // act
        var domain = CustomerServiceTestData.BillingAddressDto.ToDomain();

        // assert
        domain.Should().BeEquivalentTo(CustomerServiceTestData.BillingAddress);
    }

    [Fact]
    public void Map_address_domain_to_dto()
    {
        // act
        var dto = CustomerServiceTestData.BillingAddress.ToDto();

        // assert
        dto.Should().BeEquivalentTo(CustomerServiceTestData.BillingAddressDto);
    }

    [Fact]
    public void Map_order_dto_to_domain()
    {
        // act
        var domain = CustomerServiceTestData.OrderDto1.ToDomain();

        // assert
        domain.Should().BeEquivalentTo(CustomerServiceTestData.Order1);
    }

    [Fact]
    public void Map_order_domain_to_dto()
    {
        // act
        var dto = CustomerServiceTestData.Order1.ToDto();

        // assert
        dto.Should().BeEquivalentTo(CustomerServiceTestData.Order1);
    }
}
