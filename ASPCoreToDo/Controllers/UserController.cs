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
    public class UserController : Controller
    {
        private APIConsume Instance;
        private ISessionManager _sessionManager;
        public UserController(APIConsume api, ISessionManager sessionManager)
        {
            Instance = api;
            _sessionManager = sessionManager;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
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
                Instance.Post<User>("User/", u);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Create
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
                // aller voir dans la db si user est là
               User userCheck = Instance.PostWithReturn<LoginUser>("UserLogin/", u);
                if(userCheck is null)
                {
                    return View();
                }
                else
                {
                    _sessionManager.Id = userCheck.Id;
                    _sessionManager.Firstname = userCheck.Firstname;
                    _sessionManager.Lastname = userCheck.Lastname;
                    _sessionManager.Email = userCheck.Email;

                }

                return RedirectToAction("Index","ToDoGenerated");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Deconnexion()
        {
            _sessionManager.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}