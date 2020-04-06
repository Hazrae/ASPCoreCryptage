using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPCoreToDo.Utils;
using ASPCoreToDo.Models;

namespace ASPCoreToDo.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        //[Route("ToDo/")]
        private APIConsume instance;
        public ToDoController(APIConsume api)
        {
            instance = api;
        }
        public ActionResult ToDo()
        {
            return View(instance.Get<List<ToDo>>("ToDo/"));
        }

        // GET: ToDo/Create
        public ActionResult ToDoAdd()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToDoAdd(ToDo td)
        {
            try
            {
                instance.Post<ToDo>("ToDo/", td);

                return RedirectToAction(nameof(ToDo));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult ToDoEdit(int id)
        {
            return View(instance.Get<ToDo>("ToDo/", id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToDoEdit(int id, ToDo td)
        {
            try
            {
                instance.Put<ToDo>("ToDo/", td);

                return RedirectToAction(nameof(ToDo));
            }
            catch
            {
                return View();
            }
        }
       
        public ActionResult ToDoDelete(int id)
        {
            instance.Delete("ToDo/",id);
            return RedirectToAction(nameof(ToDo));
        }
    }
}