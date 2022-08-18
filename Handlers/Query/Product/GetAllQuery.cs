using Core.Contexts;
using Handlers.Base;
using Handlers.Requests.Product;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Query.Product
{

    public class GetAllQuery : HandlerBase<GetAllRequest>
    {
        private readonly DataContext _dataContext;

        public GetAllQuery(DataContext dataContext) : base()
        {
            _dataContext = dataContext;
        }

        public override Task<ResponseBase> Handle(GetAllRequest request, ResponseBase response)
        {
            var product = _dataContext
               .Products
               .Include(t => t.BrandValue);

            response.Result = product;

            return Task.FromResult(response);
        }
    }
}