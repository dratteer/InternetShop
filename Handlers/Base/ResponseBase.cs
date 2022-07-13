using System.Collections.Generic;
using System.Linq;

namespace Handlers.Base
{
    public class ResponseBase
    {
        public bool IsSucceeded => !this.Errors.Any();

        public List<string> Errors { get; set; } = new List<string>();

        public object Result { get; set; }

        public string Message { get; set; }
    }
}