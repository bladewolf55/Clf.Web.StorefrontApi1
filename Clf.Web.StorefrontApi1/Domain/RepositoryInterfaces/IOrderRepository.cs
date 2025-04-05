namespace Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

public interface IOrderRepository
{
    IEnumerable<DataTransfer.OrderDto> GetCustomerOrders(int customerId);
}
