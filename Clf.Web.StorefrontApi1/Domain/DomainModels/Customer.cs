namespace Clf.Web.StorefrontApi1.Domain.DomainModels;

public class Customer: DataTransfer.CustomerDto
{
    public Address BillingAddress { get; set; } = null!;
    public List<Order> Orders { get; set; } = new();

    public Customer(int id, string name, Address billingAddress, List<Order> orders)
    {
        Id = id;
        Name = name;
        BillingAddress = billingAddress;
        Orders = orders;
    }

    public List<string> Validate()
    {
        List<string> errors = new();
        if (String.IsNullOrEmpty(Name)) errors.Add( "Name required");
        if (BillingAddress == null) errors.Add("Billing Address required");
        return errors;
    }

    public bool IsValid() => Validate().Count == 0;
}
