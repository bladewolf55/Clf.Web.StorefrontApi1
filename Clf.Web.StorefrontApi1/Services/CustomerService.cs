using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Domain.Services;

namespace Clf.Web.StorefrontApi1.Services;

public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> logger;
    private readonly ICustomerRepository customerRepository;
    private readonly IAddressRepository addressRepository;
    private readonly IOrderRepository orderRepository;

    public CustomerService(ILogger<CustomerService> logger, 
        ICustomerRepository customerRepository, IAddressRepository addressRepository, IOrderRepository orderRepository)
    {
        this.logger = logger;
        this.customerRepository = customerRepository;
        this.addressRepository = addressRepository;
        this.orderRepository = orderRepository;
    }

    public Domain.DomainModels.Customer GetCustomer(int id)
    {
        throw new NotImplementedException();
    }
}
