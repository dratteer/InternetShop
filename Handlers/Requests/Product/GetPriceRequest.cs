using Handlers.Base;

namespace Handlers.Requests.Product
{
    public class GetPriceRequest : RequestBase
    {
        public long Id { get; set; }
    }
}
