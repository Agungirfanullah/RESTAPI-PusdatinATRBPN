using System.Net;

namespace PlaceAPI
{
    public class APIResponse
    {
        public bool success { get; set; }

        public string messages { get; set; }

        public HttpStatusCode error_code { get; set; }

        public Object? data { get; set; }

        public APIResponse(bool success_, string messages_, HttpStatusCode error_code_, Object data_)
        {
            success = success_;
            messages = messages_;
            error_code = error_code_;
            data = data_;
        }
    }
}
