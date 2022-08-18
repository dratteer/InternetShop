using Handlers.Base;

namespace Handlers.Requests.Product
{
    public class DeleteByIdRequest : RequestBase
    {
        public long Id { get; set; }
    }
}