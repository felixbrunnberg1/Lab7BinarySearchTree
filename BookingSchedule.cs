using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7BinarySearchTree
{
    internal class BookingSchedule
    {
        private BinarySearchTree schedule;
        private Dictionary<DateTime, Event> events;


        public BookingSchedule()
        {
            schedule = new BinarySearchTree();
        }
        public Event FindNextAvailableEvent(DateTime startTime)
        {

        }

        public void AddEvent(Event newEvent)
        {
            if (events.ContainsKey(newEvent.EventDate))
            {
                throw new Exception("Event already exists on this date.");
            }

            events.Add(newEvent.EventDate, newEvent);
            schedule.AddIterative((int)newEvent.EventDate.Ticks);
        }

        public Event[] ShowEventsAfter(DateTime startTime)
        {

        }
    }
}
