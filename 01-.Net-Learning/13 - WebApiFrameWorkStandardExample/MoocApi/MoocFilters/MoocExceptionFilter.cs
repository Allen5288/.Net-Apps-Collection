using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoocModel;

namespace MoocApi.MoocFilters
{
    public class MoocExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 2. 用 CommonResult 封装错误信息
            var result = new ApiResult
            {
                Success = false,
                Message = "Failed",
                Data = null,
                Errors = [context.Exception.Message]
            };

            // 3. 设置 HTTP 状态码和 JSON 返回
            context.Result = new JsonResult(result)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            // 4. 告诉框架：异常已经被处理，不要再继续抛
            context.ExceptionHandled = true;
        }
    }
}
