using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRTaskList.Data
{
    public class TaskManager
    {
        private string _connectionString;

        public TaskManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddTask(Chore chore)
        {
            using (var context = new TaskContext(_connectionString))
            {
                context.Tasks.Add(chore);
                context.SaveChanges();
            }
        }

        public IEnumerable<Chore> GetTasks()
        {
            using (var context = new TaskContext(_connectionString))
            {
                return context.Tasks
                    .Include(c => c.User)
                    .Where(c => c.Status != Status.Done);
                    
            }
        }
    }
}
