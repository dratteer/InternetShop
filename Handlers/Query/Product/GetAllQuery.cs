using AutoMapper;
using Core.Contexts;
using Domain.DTOs;
using Handlers.Base;
using Handlers.Requests.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Handlers.Query.Product
{
    public class GetAllQuery : HandlerBase<GetAllRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllQuery(DataContext dataContext, IMapper mapper) : base()
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override Task<ResponseBase> Handle(GetAllRequest request, ResponseBase response)
        {
            var products = _dataContext
               .Products
               .Include(t => t.BrandValue);

            response.Result = _mapper.Map<List<ProductDTO>>(products);

            return Task.FromResult(response);
        }
    }
}