namespace Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

public interface ICustomerRepository
{
    DataTransfer.CustomerDto GetCustomer(int id);
}
