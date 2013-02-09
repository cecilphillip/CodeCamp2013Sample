using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CodeCamp2013.WebApi.Filters
{
    public class LoggerAttribute : ActionFilterAttribute
    {

        private const string _loggerName = "Logger";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            LoggerService.WriteLog(_loggerName, "OnActionExecuting", actionContext.ActionDescriptor.ControllerDescriptor.ControllerName, actionContext.ActionDescriptor.ActionName);
            //terminate the request by set a new response 
            //to actionContext.Response
            //actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var actionCtx = actionExecutedContext.ActionContext;
            var controllerCtx = actionCtx.ControllerContext;

            LoggerService.WriteLog(_loggerName, "OnActionExecuted", controllerCtx.ControllerDescriptor.ControllerName, actionCtx.ActionDescriptor.ActionName);
        }
    }
}