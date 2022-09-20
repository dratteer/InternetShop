using AutoMapper;
using Core.Contexts;
using Domain.DTOs;
using Handlers.Base;
using Handlers.Requests.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Query.Product
{
    public class GetByIdQuery : HandlerBase<GetByIdRequest>
    {
        private readonly DataContext _dataContext;
        protected readonly IMapper _mapper;

        public GetByIdQuery(DataContext dataContext, IMapper mapper) : base()
        {
             _dataContext = dataContext;
            _mapper = mapper;
        }

        public override Task<ResponseBase> Handle(GetByIdRequest request, ResponseBase response)
        {
            var product = _dataContext
               .Products
               .Include(t => t.BrandValue)
               .SingleOrDefault(t => t.Id == request.Id);
              
            response.Result = _mapper.Map<ProductDTO>(product);

            return Task.FromResult(response);
        }
    }
}
