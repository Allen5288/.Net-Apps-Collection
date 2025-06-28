using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoocModel;

namespace MoocApi.MoocFilters
{
    public class MoocResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            // 在结果执行前处理
            if (context.Result is ObjectResult objectResult)
            {
                // 如果已经是我们的统一格式，则添加时间戳
                if (objectResult.Value is ApiResult apiResult)
                {
                    // 确保 Errors 不为 null
                    apiResult.Errors ??= Array.Empty<object>();

                    // 添加时间戳
                    apiResult.Data = new
                    {
                        Timestamp = DateTime.UtcNow,
                        Content = apiResult.Data
                    };
                }
                else
                {
                    // 如果不是统一格式，转换为统一格式
                    var newApiResult = new ApiResult
                    {
                        Success = true,
                        Message = "Operation succeeded",
                        Data = new
                        {
                            Timestamp = DateTime.UtcNow,
                            Content = objectResult.Value
                        },
                        Errors = Array.Empty<object>()
                    };

                    objectResult.Value = newApiResult;
                    objectResult.DeclaredType = typeof(ApiResult);
                }
            }

        }
    }
}
