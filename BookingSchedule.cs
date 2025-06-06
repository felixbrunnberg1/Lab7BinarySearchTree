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

        private Dictionary<int, Event> events;


        public BookingSchedule()
        {
            schedule = new BinarySearchTree();
        }

        public Event FindNextAvailableEvent(DateTime startTime)
        {
            int startTimeInt = (int)startTime.Ticks;
            TreeNode nextEvent = schedule.GetNextInorder(startTimeInt);
            return events[nextEvent.Value];
        }

        public void AddEvent(Event newEvent)
        {
            if (events.ContainsKey((int)newEvent.EventDate.Ticks))
            {
                throw new Exception("Event already exists on this date.");
            }

            events.Add((int)newEvent.EventDate.Ticks, newEvent);
            schedule.AddIterative((int)newEvent.EventDate.Ticks);
        }

        public void ShowEventsAfter(DateTime startTime)
        {
            while(schedule.root != null)
            {
                Event current = FindNextAvailableEvent(startTime);
                if (current == null)
                {
                    break;
                }
                Event ev = events[(int)current.EventDate.Ticks];
                Console.WriteLine($"Event: {ev.EventName}, Date: {ev.EventDate}");
                startTime = ev.EventDate;
            }
        }

    }
}
