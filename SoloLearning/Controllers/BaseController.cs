using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SoloLearning.Web.Models;

namespace SoloLearning.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        #region Response Results
        protected OkObjectResult ApiResult<T>(T model = default)
        {
            return new OkObjectResult(new ApiResponseModel<T>(model));
        }

        protected OkObjectResult ApiResult<T>()
        {
            return ApiResult<object>();
        }

        protected JsonResult ApiErrorResult<T>(T model = default)
        {
            return new JsonResult(new { success = false, data = model });
        }

        protected OkObjectResult Error(ModelStateDictionary model)
        {
            List<ErrorModel> errors = new List<ErrorModel>();
            model.ToList().ForEach(s =>
            {
                errors.AddRange(s.Value.Errors.Select(e =>
                new ErrorModel(s.Key, e.ErrorMessage)));
            });

            return Error(new ErrorResponseModel(errors));
        }

        protected OkObjectResult Error(string key)
        {
            return Error("Error", key);
        }

        protected OkObjectResult Error(string key, string message)
        {
            return Error(new ErrorResponseModel(key, message));
        }

        protected OkObjectResult Error(ErrorResponseModel model)
        {
            return new OkObjectResult(model);
        }

        protected OkObjectResult Error()
        {
            return Error(ControllerContext.ModelState);
        }

        protected OkObjectResult HandleException(Exception e)
        {
            return Error("Exception", e.Message);
        }

        #endregion
    }
}