namespace Clf.Web.StorefrontApi1.Data.Models;
public class Address
{
    public int AddressId { get; set; }
    public int CustomerId { get; set; }
    public string AddressType { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string StateAbbreviation { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

}
