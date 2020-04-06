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
    public class ToDoGeneratedController : Controller
    {
        private APIConsume instance;
        private ISessionManager _sessionManager;
        public ToDoGeneratedController(APIConsume api, ISessionManager sessionManager)
        {
            instance = api;
            _sessionManager = sessionManager;
        }
        // GET: ToDoGenerated
        public ActionResult Index()
        {
            if (_sessionManager.Id == -1)
                return RedirectToAction("Login", "User");
            return View(instance.Get<List<ToDo>>("ToDoByUser/",_sessionManager.Id));
        }

        // GET: ToDoGenerated/Details/5
        public ActionResult Details(int id)
        {
            if (_sessionManager.Id == -1)
                return RedirectToAction("Login", "User");
            return View(instance.Get<ToDo>("ToDo/",id));
        }

        // GET: ToDoGenerated/Create
        public ActionResult Create()
        {
            if (_sessionManager.Id == -1)
                return RedirectToAction("Login", "User");
            return View();
        }

        // POST: ToDoGenerated/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo td)
        {
            try
            {
                instance.Post<ToDo>("ToDo/", td);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoGenerated/Edit/5
        public ActionResult Edit(int id)
        {
            if (_sessionManager.Id == -1)
                return RedirectToAction("Login", "User");
            return View(instance.Get<ToDo>("ToDo/", id));
        }

        // POST: ToDoGenerated/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDo td)
        {
            try
            {
                instance.Put<ToDo>("ToDo/", td);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoGenerated/Delete/5
        public ActionResult Delete(int id)
        {
            if (_sessionManager.Id == -1)
                return RedirectToAction("Login", "User");
            instance.Delete("ToDo/", id);
            return RedirectToAction(nameof(Index));
        }

    }
}