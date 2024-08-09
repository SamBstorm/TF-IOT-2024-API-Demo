namespace ASP_WebAPI.Models
{
    public interface IApiResult<T>
    {
        T result { get; set; }
        int length {  get; set; }
        int statusCode { get; set; }
    }
}
