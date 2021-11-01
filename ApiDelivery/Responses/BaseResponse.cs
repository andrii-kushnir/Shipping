using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ApiDelivery.Responses
{
    public class BaseResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public BaseResponse()
        {
            status = false;
            message = "";
        }

        public BaseResponse(bool status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
        }
    }
}
