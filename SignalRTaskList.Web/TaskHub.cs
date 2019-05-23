using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTaskList.Data
{
    public class TaskHub : Hub
    {
        private string _connectionString;
        private static int _count;

        public TaskHub(IConfiguration configuration)
        {
            //_connectionString = configuration.GetConnectionString("ConStr");
        }

        public void SendTask(string title)
        {
            TaskManager mgr = new TaskManager(_connectionString);
            Chore c = new Chore();
            c.Title = title;
            c.Status = Status.NotStarted;

            Clients.All.SendAsync("NewTask", c);

        }

        public void UpdateStatus(int id, Status status)
        {
            TaskManager mgr = new TaskManager(_connectionString);
            
        }

        public void NewUser()
        {
            
            string email  = Context.User.Identity.Name;
            Clients.All.SendAsync("NewUsers", email);
        }
    }
}
