﻿using Core.Contexts;
using Handlers.Base;
using Handlers.Requests.Product;
using Microsoft.EntityFrameworkCore;
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
               .Include(t => t.BrandValue)
               .SingleOrDefault(t => t.Id == request.Id);
              
            response.Result = product;

            return Task.FromResult(response);
        }
    }
}
