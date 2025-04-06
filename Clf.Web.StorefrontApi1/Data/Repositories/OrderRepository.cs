using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

namespace Clf.Web.StorefrontApi1.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    SqlDbContext db;

    public OrderRepository(SqlDbContext db)
    {
        this.db = db;
    }

    public IEnumerable<OrderDto> GetCustomerOrders(int customerId)
    {
        var orders =
            from order in db.Orders
            join address in db.Addresses on order.ShipToId equals address.AddressId
            where order.CustomerId == customerId
            select new { order, address };

        var dto = orders.Select(a => new OrderDto()
        {
            Number = a.order.OrderId,
            OrderedOn = a.order.OrderedOn,
            ShipTo = new AddressDto()
            {
                AddressType = Enum.Parse<AddressType>(a.address.AddressType),
                Address1 = a.address.Address1,
                City = a.address.City,
                State = a.address.StateAbbreviation,
                Zip = a.address.PostalCode
            }
        });

        return dto;
    }
}
