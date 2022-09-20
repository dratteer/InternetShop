using Handlers.Base;
using Handlers.Requests.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ResponseBase> GetById(long id)
        {
            var response = await _mediator.Send(new GetByIdRequest
            {
                Id = id
            });

            return response;
        }

        [HttpGet("{id}/price")]
        public async Task<ResponseBase> GetPrice(long id)
        {
            var response = await _mediator.Send(new GetPriceRequest
            {
                Id = id
            });

            return response;
        }

        [HttpGet]
        public async Task<ResponseBase> GetAll()
        {
            var response = await _mediator.Send(new GetAllRequest { });

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseBase> Delete(long id)
        {
            var response = await _mediator.Send(new DeleteByIdRequest
            {
                Id = id
            });

            return response;
        }
    }
}