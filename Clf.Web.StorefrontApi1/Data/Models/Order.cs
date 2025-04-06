namespace Clf.Web.StorefrontApi1.Data.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ShipToId { get; set; }
    public DateTime OrderedOn { get; set; }

}
