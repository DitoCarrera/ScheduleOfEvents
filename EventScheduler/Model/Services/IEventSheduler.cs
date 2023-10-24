using EventScheduler.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Model.Services
{
    internal interface IEventSheduler
    {
        public void AddEvent(Event @event);
        public Event FindEvent(string title, DateTime startDate);
        public void RemoveEvent(string title, DateTime startDate);
        public List<Event> GetEventsForDate(DateTime date);
        public List<Event> SortEvents(int numberOfEvents);

    }
}
