namespace Clf.Web.StorefrontApi1.Domain.DataTransfer
{
    public class OrderDto
    {
        public int Number { get; set; }
        public DateTime OrderedOn { get; set; }

        public AddressDto? ShipTo { get; set; }
    }
}
