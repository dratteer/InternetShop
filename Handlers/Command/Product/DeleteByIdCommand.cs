using Core.Contexts;
using Handlers.Base;
using Handlers.Requests.Product;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Command.Product
{

    public class DeleteByIdCommand : HandlerBase<DeleteByIdRequest>
    {
        private readonly DataContext _dataContext;

        public DeleteByIdCommand(DataContext dataContext) : base()
        {
            _dataContext = dataContext;
        }

        public override Task<ResponseBase> Handle(DeleteByIdRequest request, ResponseBase response)
        {
            var product = _dataContext
               .Products
               .SingleOrDefault(t => t.Id == request.Id);

            if (product != null)
            {
                _dataContext.Remove(product);
                _dataContext.SaveChanges();
            }

            return Task.FromResult(response);
        }
    }
}
