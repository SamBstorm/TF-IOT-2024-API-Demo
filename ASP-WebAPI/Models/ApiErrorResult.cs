﻿namespace ASP_WebAPI.Models
{
    public class ApiErrorResult<T>
    {
        public string Message { get; set; }
        public T Error { get; set; }
        public string ParameterName { get; set; }
        public int statusCode { get; set; }
    }
}
