namespace ASP_WebAPI.Models
{
    public class ApiResult<T> : IApiResult<T>
    {
        public T result { get ; set ; }
        public int length { get; set; }
        public int statusCode { get; set; }
    }
}
