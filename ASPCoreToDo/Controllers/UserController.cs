using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreToDo.Infrastructure;
using ASPCoreToDo.Models;
using ASPCoreToDo.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Cryptography;

namespace ASPCoreToDo.Controllers
{
    [AnonymousRequired]
    public class UserController : ControllerBase
    {
        private APIConsume Instance;
        private IRSAEncryption _encrypt;
        public UserController(APIConsume api, ISessionManager sessionManager): base(sessionManager)
        {
            Instance = api;            
        }
        /*register api sans crypto
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
        */

        // GET: User/Create
        //Register
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterUser u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    byte[] pwEncrypt;
                    _encrypt = new RSAEncryption(Instance.Get<byte[]>("Auth"));                                     
                    pwEncrypt = _encrypt.Encrypt(u.Password);
                    u.Password = Convert.ToBase64String(pwEncrypt);
                    Instance.Post<RegisterUser>("User/", u);
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