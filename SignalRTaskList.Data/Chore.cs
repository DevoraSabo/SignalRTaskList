using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRTaskList.Data
{
    public class Chore
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
