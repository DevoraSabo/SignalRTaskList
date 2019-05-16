﻿using Microsoft.Extensions.Configuration;
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

        public object Clients { get; private set; }
        public object Context { get; private set; }

        public TaskHub(IConfiguration configuration)
        {
            //_connectionString = configuration.GetConnectionString("ConStr");
        }

        public void SendTask(Chore chore)
        {
            Clients.All.SendAsync("NewTask", chore);
        }

        public void NewUser()
        {
            User u = new User();
            u = Context.User.Identity.Name;
            Clients.All.SendAsync("NewUsers", u);
        }
    }
}
