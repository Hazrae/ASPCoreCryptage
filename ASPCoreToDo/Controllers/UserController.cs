using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreToDo.Infrastructure;
using ASPCoreToDo.Models;
using ASPCoreToDo.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ASPCoreToDo.Controllers
{
    [AnonymousRequired]
    public class UserController : ControllerBase
    {
        private APIConsume Instance;      
        public UserController(APIConsume api, ISessionManager sessionManager): base(sessionManager)
        {
            Instance = api;   
        }             

        // GET: User/Create
        //Register
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Instance.Post<User>("User/", u);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(u);
                }
            }
            catch
            {
                return View(u);
            }
        }

        // GET: User/Create
        //Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User userCheck = Instance.PostWithReturn<LoginUser>("UserLogin/", u);
                    if (userCheck.Id == 0)
                    {
                        return RedirectToAction("Create", "User");
                    }
                    else
                    {
                        SessionManager.Id = userCheck.Id;
                        SessionManager.Firstname = userCheck.Firstname;
                        SessionManager.Lastname = userCheck.Lastname;
                        SessionManager.Email = userCheck.Email;
                        return RedirectToAction("Index", "Home");
                    }
                }

                return View(u);
                
            }
            catch
            {
                return View(u);
            }
        }        

        public ActionResult Deconnexion()
        {
            SessionManager.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}