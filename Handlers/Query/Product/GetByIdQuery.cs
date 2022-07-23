using Core.Contexts;
using Handlers.Base;
using Handlers.Requests.Product;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Query.Product
{
    public class GetByIdQuery : HandlerBase<GetByIdRequest>
    {
        private readonly DataContext _dataContext;

        public GetByIdQuery(DataContext dataContext) : base()
        {
             _dataContext = dataContext;
        }

        public override Task<ResponseBase> Handle(GetByIdRequest request, ResponseBase response)
        {
            var product = _dataContext
               .Products
               .Where(t => t.Id == request.Id)
               .FirstOrDefault();
               
            //  response.Result = product;

            /*IQueryable product = from x in _dataContext.Products
                               where x.Id == 1
                               select x;*/

            response.Result = product;

            return Task.FromResult(response);
        }
    }
}
