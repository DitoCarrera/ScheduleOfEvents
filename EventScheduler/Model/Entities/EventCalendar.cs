using EventScheduler.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Model.Entities
{
    internal class EventCalendar : IEventSheduler
    {
        public List<Event> Events { get; private set; } = new List<Event>();

        public void AddEvent(Event @event)
        {
            if (Events.Any(e =>
            (@event.StartDate >= e.StartDate && @event.StartDate <= e.EndDate) ||
            (@event.EndDate >= e.StartDate && @event.EndDate <= e.EndDate) ||
            (@event.StartDate <= e.StartDate && @event.EndDate >= e.EndDate)))
            {
                throw new ArgumentException("Time conflict: An event is already scheduled for the same time interval.");
            }
            Events.Add(@event);
        }

        public Event FindEvent(string title, DateTime startDate)
        {
            Event @event = Events.FirstOrDefault(e => e.Title == title && e.StartDate == startDate);

            return @event;
        }

        public List<Event> GetEventsForDate(DateTime date)
        {
            if (Events.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation: The list of events is empty.");
            }

            if (date <= DateTime.Now)
            {
                throw new InvalidOperationException("Invalid operation: The date is in the past or equal to the current date.");
            }

            List<Event> eventsForDate = Events.Where(e => e.StartDate == date.Date).OrderBy(e => e.StartDate).Take(10).ToList();

            return eventsForDate;
        }

        public void RemoveEvent(string title, DateTime startDate)
        {
            if (Events.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation: The list of events is empty.");
            }

            Events.Remove(FindEvent(title, startDate));  
        }

        public List<Event> SortEvents(int numberOfEvents)
        {
            if (Events.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation: The list of events is empty.");
            }

            List<Event> events = Events;

            events.Sort();
            return events.Skip(numberOfEvents).Take(10).ToList();
           
        }

        
    }
}
