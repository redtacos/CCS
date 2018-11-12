using System;

namespace ccs.Models
{
    public class ApiMessage<T> where T: class
    {
        public int status { get; set; }
        public object message { get; set; }
        public T data { get; set; }
    }
}