namespace Clf.Web.StorefrontApi1.Domain.DomainModels;

public class Order: DataTransfer.OrderDto
{
    public Address ShipTo { get; set; } = null!;

}
