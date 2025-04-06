using Clf.Web.StorefrontApi1.Domain.DataTransfer;
using Clf.Web.StorefrontApi1.Domain.DomainModels;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;

namespace Clf.Web.StorefrontApi1.Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly SqlDbContext db;

    public AddressRepository(SqlDbContext db)
    {
        this.db = db;
    }

    public IEnumerable<AddressDto> GetCustomerAddresses(int customerId)
    {
        var addresses = db.Addresses.Where(a => a.CustomerId == customerId).ToList();
        var dto = addresses.Select(a => new AddressDto()
        {
            Address1 = a.Address1,
            AddressType = Enum.Parse<AddressType>(a.AddressType),
            City = a.City,
            State = a.StateAbbreviation,
            Zip = a.PostalCode
        });

        return dto;
    }
}
