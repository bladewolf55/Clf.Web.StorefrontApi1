using Clf.Web.StorefrontApi1.Domain.DataTransfer;

namespace Clf.Web.StorefrontApi1.Domain.DomainModels;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address? BillingAddress { get; set; }
    public List<Order> Orders { get; set; } = new();
    public List<string> Validate()
    {
        List<string> errors = new();
        if (String.IsNullOrEmpty(Name)) errors.Add( "Name required");
        if (BillingAddress == null) errors.Add("Billing Address required");
        return errors;
    }

    public bool IsValid() => Validate().Count == 0;
}
