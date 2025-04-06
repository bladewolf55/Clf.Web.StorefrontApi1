using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Microsoft.AspNetCore.Http;

namespace Clf.Web.StorefrontApi1.UnitTests;

static internal class CustomerServiceTestData
{
    // CUSTOMER

    public static CustomerDto CustomerDto
    {
        get
        {
            return new CustomerDto()
            {
                Id = 1,
                Name = "name",
                BillingAddress = BillingAddressDto,
                Orders = new List<OrderDto>
                {
                    OrderDto1,
                    OrderDto2,
                }
            };
        }
    }

    public static Customer Customer
    {
        get
        {
            var dto = CustomerDto;
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                BillingAddress = BillingAddress,
                Orders = new()
                {
                    Order1,
                    Order2,
                }
            };
        }
    }

    // ADDRESS

    public static AddressDto BillingAddressDto { get
        {
            return new AddressDto()
            {
                Address1 = "billing address 1",
                Address2 = "billing address 2",
                City = "Denver",
                State = "CO",
                Zip = "80201"
            };
        }
    }

    public static Address BillingAddress
    {
        get 
        {
            var dto = BillingAddressDto;
            return new Address()
            {
                AddressType = dto.AddressType,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip
            };
        }
    }

    public static AddressDto ShippingAddressDto1
    {
        get
        {
            return new AddressDto()
            {
                Address1 = "shipping address 1",
                Address2 = "shipping address 2",
                City = "Ponca City",
                State = "OK",
                Zip = "74601"
            };
        }
    }

   public static Address ShippingAddress1 { get
        {
            var dto = ShippingAddressDto1;
            return new Address()
            {
                AddressType = dto.AddressType,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip
            };
        } 
    }

    public static AddressDto ShippingAddressDto2
    {
        get
        {
            return new AddressDto()
            {
                Address1 = "shipping address 1",
                Address2 = "shipping address 2",
                City = "Pocatello",
                State = "ID",
                Zip = "83201"
            };
        }
    }
    
    public static Address ShippingAddress2 { get
        {
            var dto = ShippingAddressDto2;
            return new Address()
            {
                AddressType = dto.AddressType,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip
            };
        } }

    // ORDER

    public static OrderDto OrderDto1 { get
        {
            return new OrderDto()
            {
                Number = 101,
                OrderedOn = DateTime.Parse("2025-04-01"),
                ShipTo = ShippingAddressDto1,
            };
        }
    }

    public static Order Order1
    {
        get
        {
            var dto = OrderDto1;
            return new Order()
            {
                Number = dto.Number,
                OrderedOn = dto.OrderedOn,
                ShipTo = ShippingAddress1
            };
        }
    }
    public static OrderDto OrderDto2
    {
        get
        {
            return new OrderDto()
            {
                Number = 102,
                OrderedOn = DateTime.Parse("2025-04-02"),
                ShipTo = ShippingAddressDto2,
            };
        }
    }

    public static Order Order2
    {
        get
        {
            var dto = OrderDto2;
            return new Order()
            {
                Number = dto.Number,
                OrderedOn = dto.OrderedOn,
                ShipTo = ShippingAddress2
            };
        }
    }

}