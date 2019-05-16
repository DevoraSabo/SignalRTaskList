using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRTaskList.Data
{
   
        public class TaskContext : DbContext
        {
            private string _connectionString;

            public TaskContext(string connectionString)
            {
                _connectionString = connectionString;
            }

            public DbSet<Chore> Tasks { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    .UseSqlServer(_connectionString);
            }

        public DbSet<User> Users { get; set; }
        public DbSet<Chore> Chores { get; set; }
        }
    
}
