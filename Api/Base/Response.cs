using System.Collections.Generic;

namespace Api.Base
{
    public class Response<T>
    {
        public bool success { get; set; }
        public List<T> data { get; set; }
        public List<string> errors { get; set; }
        public List<object> warnings { get; set; }
        public object info { get; set; }
        public List<string> messageCodes { get; set; }
        public object errorCodes { get; set; }
        public List<string> warningCodes { get; set; }
        public List<string> infoCodes { get; set; }
    }

    public class Info
    {
        public int totalCount { get; set; }
    }
}
