using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.DomainModels;

namespace Clf.Web.StorefrontApi1.Domain.DataMapping;

public static class DataMapping
{
    public static Customer ToDomain(this CustomerDto dto)
    {
        return new Customer()
        {
            Id = dto.Id,
            Name = dto.Name,
            BillingAddress = dto.BillingAddress?.ToDomain(),
            Orders = dto.Orders.Select(o => o.ToDomain()).ToList(),
        };
    }

    public static CustomerDto ToDto(this Customer domain)
    {
        return new CustomerDto()
        {
            Id = domain.Id,
            Name = domain.Name,
            BillingAddress = domain.BillingAddress?.ToDto(),
            Orders = domain.Orders.Select(a => a.ToDto()).ToList(),
        };
    }

    public static Order ToDomain(this OrderDto dto)
    {
        return new Order()
        {
            Number = dto.Number,
            OrderedOn = dto.OrderedOn,
            ShipTo = dto.ShipTo?.ToDomain()
        };
    }

    public static OrderDto ToDto(this Order domain)
    {
        return new OrderDto()
        {
            Number = domain.Number,
            OrderedOn = domain.OrderedOn,
            ShipTo = domain.ShipTo?.ToDto()
        };
    }

    public static Address ToDomain(this AddressDto dto)
    {
        return new Address()
        {
            AddressType = dto.AddressType,
            Address1 = dto.Address1,
            Address2 = dto.Address2,
            City = dto.City,
            State = dto.State,
            Zip = dto.Zip,
        };
    }

    public static AddressDto ToDto(this Address domain)
    {
        return new AddressDto()
        {
            AddressType = domain.AddressType,
            Address1 = domain.Address1,
            Address2 = domain.Address2,
            City = domain.City,
            State = domain.State,
            Zip = domain.Zip,
        };
    }
}
