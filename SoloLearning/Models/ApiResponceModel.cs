using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoloLearning.Web.Models
{
    public abstract class ResponseModel<TData>
    {
        public bool Success { get; set; } = true;
        public TData Data { get; set; }
    }
    
    public class ErrorModel
    {
        public ErrorModel(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponseModel<TData> : ResponseModel<TData>
    {
        public ApiResponseModel(TData data)
        {
            this.Data = data;
        }
    }

    public class ErrorResponseModel : ResponseModel<List<ErrorModel>>
    {
        public ErrorResponseModel()
        {
            Data = new List<ErrorModel>();
            Success = false;
        }
        public ErrorResponseModel(List<ErrorModel> errors) : this()
        {
            Data = errors;
        }
        public ErrorResponseModel(string key, string message) : this()
        {
            Data.Add(new ErrorModel(key, message));
        }
    }
}
