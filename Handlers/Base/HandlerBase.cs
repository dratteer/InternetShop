using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Handlers.Base
{
    public abstract class HandlerBase<T> : IRequestHandler<T, ResponseBase> where T : RequestBase
    {
        protected HandlerBase() { }

        public virtual T Validate(T request)
        {
            return request;
        }

        public async Task<ResponseBase> Handle(T request, CancellationToken cancellationToken)
        {
            var response = new ResponseBase();

            try
            {
                request = this.Validate(request);

                if (request.IsValid)
                {
                    await this.Handle(request, response);
                }
                else
                {
                    response.Errors.AddRange(request.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        public abstract Task<ResponseBase> Handle(T request, ResponseBase response);
    }
}