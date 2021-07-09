using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiNovaPost.Base;

namespace ApiNovaPost
{
    public class ResponseWrap<TResponse>
    {
        public Response<TResponse> Response { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
