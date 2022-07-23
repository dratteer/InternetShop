using Handlers.Base;
using Handlers.Requests.Product;
using System.Threading.Tasks;

namespace Handlers.Query.Product
{
    public class GetPriceQuery : HandlerBase<GetPriceRequest>
    {
        public GetPriceQuery() : base()
        {

        }

        public override Task<ResponseBase> Handle(GetPriceRequest request, ResponseBase response)
        {
            var Price = 123;
            var product = "Тут типа я получаю цену продукта с номером #: " + request.Id + Price;

            response.Result = product;

            return Task.FromResult(response);
        }
    }
}
