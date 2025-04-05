using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

namespace Clf.Web.StorefrontApi1.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public IEnumerable<AddressDto> GetCustomerAddresses(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
