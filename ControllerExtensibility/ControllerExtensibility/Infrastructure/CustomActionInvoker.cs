using System;
using System.Web.Mvc;
using ControllerExtensibility.Infrastructure;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName == "Index")
            {
                controllerContext.HttpContext.Response.Write("This is output from the Index action");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}