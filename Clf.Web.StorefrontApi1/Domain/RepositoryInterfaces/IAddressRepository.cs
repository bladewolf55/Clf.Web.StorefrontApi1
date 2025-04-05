namespace Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

public interface IAddressRepository
{
    IEnumerable<DataTransfer.AddressDto> GetCustomerAddresses(int customerId);
}
