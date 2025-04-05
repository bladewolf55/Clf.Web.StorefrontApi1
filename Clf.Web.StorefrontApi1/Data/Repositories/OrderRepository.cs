using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

namespace Clf.Web.StorefrontApi1.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    public IEnumerable<OrderDto> GetCustomerOrders(int customerId)
    {
        throw new NotImplementedException();
    }
}
