using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7BinarySearchTree
{
    internal class Event
    {
        public readonly string EventName;
        public readonly DateTime EventDate;

        public Event(string EventName, DateTime EventDate)
        {
            this.EventName = EventName;
            this.EventDate = EventDate;
        }
    }
}
