using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Handlers.Base
{
    public abstract class RequestBase : IRequest<ResponseBase>
    {
        public bool IsValid => !this.ValidationErrors.Any();

        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}