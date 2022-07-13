using Handlers.Base;

namespace Handlers.Requests.Product
{
    public class GetByIdRequest : RequestBase
    {
        public long Id { get; set; }
    }
}