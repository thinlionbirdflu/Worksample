using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.Repositories;
using WorkSample.ClassLibrary.Services;

namespace WorkSample.TaskList.Mvc.Api.Controllers
{
    public class TaskController : Controller
    {
        public static TasksService service;

        public TaskController()
        {

            service = new TasksService(new TasksRepository());
        }
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult GetAll()
        {
            return Content(JsonConvert.SerializeObject(service.GetAll()), "application/json");
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(Tasks task)
        {
            try
            {
                if (task.IsValid())
                {
                    service.Add(task);
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tasks task)
        {
            try
            {
                if (task.IsValid())
                {
                    service.Update(id, task);
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
