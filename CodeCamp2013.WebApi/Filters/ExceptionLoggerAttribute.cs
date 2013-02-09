using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace CodeCamp2013.WebApi.Filters
{
    public class ExceptionLoggerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            LoggerService.WriteExceptionLog("ExceptionLogger", controllerName, actionName, actionExecutedContext.Exception.Message);
        }
    }
}