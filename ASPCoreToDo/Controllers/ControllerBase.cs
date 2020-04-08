using ASPCoreToDo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Controllers
{
    [LoggedIn]
    public class ControllerBase : Controller
    {
        protected internal ISessionManager SessionManager { get; private set; }

        protected internal ControllerBase(ISessionManager sessionManager)
        {
            SessionManager = sessionManager;
        }
    }
}
