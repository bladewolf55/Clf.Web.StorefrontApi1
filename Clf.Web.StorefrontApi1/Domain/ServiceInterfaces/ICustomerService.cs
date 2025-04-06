using Clf.Web.StorefrontApi1.Domain.DomainModels;

namespace Clf.Web.StorefrontApi1.Domain.Services;
public interface ICustomerService
{
    Customer GetCustomer(int id);
}