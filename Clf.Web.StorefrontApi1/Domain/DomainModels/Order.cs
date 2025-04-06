namespace Clf.Web.StorefrontApi1.Domain.DomainModels;
public class Order
{
    public int Number { get; set; }
    public DateTime OrderedOn { get; set; }
    public Address? ShipTo { get; set; }

    public override string ToString()
    {
        return $"{Number.ToString().PadLeft(10)} {OrderedOn.ToShortDateString()}";
    }
}
