using Newtonsoft.Json;

namespace ApiNovaPost.Base
{
    public class Request<T>
    {
        public string apiKey { get; set; }
        public string modelName { get; set; }
        public string calledMethod { get; set; }
        public T methodProperties { get; set; }

        public Request(string modelName_, string calledMethod_, T methodProperties_)
        {
            modelName = modelName_;
            calledMethod = calledMethod_;
            methodProperties = methodProperties_;
        }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd.MM.yyyy" });
        }
    }
}
