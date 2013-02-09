using System.Diagnostics;

namespace CodeCamp2013.WebApi
{
    public static class LoggerService
    {
        public static void WriteLog(string loggerName, string loggerMethodName, string controllerName, string actionName)
        {
            const string logFormat = "{0}, {1} method for Controller {2}, Action {3} is running...";
            Trace.TraceInformation(logFormat, loggerName, loggerMethodName, actionName, controllerName);
        }

        public static void WriteExceptionLog(string loggerName, string controllerName, string actionName, string exceptionMessage)
        {
            Trace.TraceInformation("{0} exception filter, for Controller {1}, Action {2} is running... Exception Message: {3}", loggerName, actionName, controllerName, exceptionMessage);
        }
    }
}