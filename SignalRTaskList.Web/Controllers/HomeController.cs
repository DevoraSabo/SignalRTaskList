using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SignalRTaskList.Data;
using SignalRTaskList.Web.Models;

namespace SignalRTaskList.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            TaskManager mgr = new TaskManager(_connectionString);
            var t = mgr.GetTasks();
            return View(t);
        }

        public IActionResult AddTask(Chore c)
        {
            TaskManager mgr = new TaskManager(_connectionString);
            mgr.AddTask(c);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

       
    }
}
