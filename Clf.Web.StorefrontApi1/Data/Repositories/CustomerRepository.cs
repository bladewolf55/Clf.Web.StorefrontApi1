using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

namespace Clf.Web.StorefrontApi1.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    SqlDbContext db;
    IOrderRepository orderRepository;
    IAddressRepository addressRepository;

    public CustomerRepository(SqlDbContext db, IOrderRepository orderRepository, IAddressRepository addressRepository)
    {
        this.db = db;
        this.orderRepository = orderRepository;
        this.addressRepository = addressRepository;
    }

    public CustomerDto GetCustomer(int customerId)
    {
        var customer = db.Customers.Find(customerId);
        if (customer == null)
            throw new Exception("Customer not found");

        var ordersDto = orderRepository.GetCustomerOrders(customerId);
        var billingAddressDto = addressRepository.GetCustomerAddresses(customerId)
            .SingleOrDefault(a => a.AddressType == Domain.DomainModels.AddressType.Billing);

        var dto = new CustomerDto()
        {
            Id = customer.CustomerId,
            Name = customer.CustomerName,
            BillingAddress = billingAddressDto,
            Orders = ordersDto.ToList()
        };

        return dto;
    }
}
