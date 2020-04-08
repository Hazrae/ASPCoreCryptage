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
    [AuthRequired]
    public class ToDoGeneratedController : ControllerBase
    {
        private APIConsume instance;   
        public ToDoGeneratedController(APIConsume api, ISessionManager sessionManager): base(sessionManager)
        {
            instance = api;         
        }
        
        public ActionResult Index()
        {            
            return View(instance.Get<List<ToDo>>("ToDoByUser/",SessionManager.Id));
        }

        // GET: ToDoGenerated/Create
        public ActionResult Create()
        {      
            return View();
        }

        // POST: ToDoGenerated/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo td)
        {
            try
            {
                td.UserId = SessionManager.Id;
                instance.Post<ToDo>("ToDo/", td);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        // GET: ToDoGenerated/Details/5
        public ActionResult Details(int id)
        {     
            return View(instance.Get<ToDo>("ToDo/",id));
        }

        // GET: ToDoGenerated/Delete/5
        public ActionResult Delete(int id)
        {       
            instance.Delete("ToDo/", id);
            return RedirectToAction(nameof(Index));
        }

        
        // GET: ToDoGenerated/Edit/5
        public ActionResult Edit(int id)
        {          
            return View(instance.Get<ToDo>("ToDo/", id));
        }

        // POST: ToDoGenerated/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDo td)
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
        
    }
}