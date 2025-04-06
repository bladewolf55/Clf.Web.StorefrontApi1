using Clf.Web.StorefrontApi1.Domain.DataTransfer;

namespace Clf.Web.StorefrontApi1.Domain.DomainModels;

public class Address
{
    public AddressType AddressType { get; set; }
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Address1}\n{Address2}\n{City}, {State}  {Zip}";
    }
}
