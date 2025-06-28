using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace MoocApi.MoocFilters
{
    public class MoocActionFilter :IActionFilter
    {
        private bool _isLog;
        public MoocActionFilter(bool isLog)
        {
            this._isLog = isLog;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext actionDescriptor = context.HttpContext;
            if (_isLog && actionDescriptor != null)
            {
                var query = actionDescriptor.Request.Query;
                StringBuilder stringBuilder = new StringBuilder();
                var method = actionDescriptor.Request.Method.ToString();
                stringBuilder.AppendFormat("method:{0} ",method);
                foreach (var parameter in query)
                {
                    stringBuilder.AppendFormat("parameter.key:{0} value:{1}", parameter.Key, parameter.Value);
                }
                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}
