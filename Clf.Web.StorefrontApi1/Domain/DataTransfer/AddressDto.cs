using Clf.Web.StorefrontApi1.Domain.DomainModels;

namespace Clf.Web.StorefrontApi1.Domain.DataTransfer
{
    public class AddressDto
    {
        public AddressType AddressType { get; set; }
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

    }
}
