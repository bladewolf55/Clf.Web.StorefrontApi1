namespace Clf.Web.StorefrontApi1.Domain.DataTransfer;
public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public AddressDto? BillingAddress { get; set; }
    public List<OrderDto> Orders { get; set; } = new();

}
