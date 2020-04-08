using ASPCoreToDo.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LoggedInAttribute : ActionFilterAttribute
    {       
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerBase controller = (ControllerBase)context.Controller;
            controller.ViewBag.isLogged = (controller.SessionManager.Id != -1);
        }
    }
}
