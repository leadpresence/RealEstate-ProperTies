using System;
namespace PMS.Models.Dtos
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public Exception? Ex { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}

