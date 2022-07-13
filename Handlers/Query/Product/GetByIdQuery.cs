using Handlers.Base;
using Handlers.Requests.Product;
using System.Threading.Tasks;

namespace Handlers.Query.Product
{
    public class GetByIdQuery : HandlerBase<GetByIdRequest>
    {
        public GetByIdQuery() : base()
        {

        }

        public override Task<ResponseBase> Handle(GetByIdRequest request, ResponseBase response)
        {
            var product = "Тут типа я получаю продукт с номером #: " + request.Id;

            response.Result = product;

            return Task.FromResult(response);
        }
    }
}
