using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Model.Entities
{
    internal class Event : IComparable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Event () { }

        public Event(string title, string description, Location location, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            Location = location;
            if (startDate <= DateTime.Now)
            {
                throw new InvalidOperationException("The start date must be after the current date");
            }
            StartDate = startDate;
            if (endDate <= StartDate)
            {
                throw new InvalidOperationException("The end date must be after the start date");
            }
            EndDate = endDate;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Event))
            {
                throw new ArgumentException("Comparing error: argument is not an Event");
            }

            Event other = obj as Event;

            return StartDate.CompareTo(other.StartDate);
        }

        public override string ToString()
        {
            return "-=-=-=-=-=-=-=-=-=-=-"
                + "\nTitle: "
                + Title
                + "\nDescription: "
                + Description
                + "\nLocation: "
                + Location
                + "\nStartDate: "
                + StartDate
                + "\nEndDate: "
                + EndDate
                + "\n-=-=-=-=-=-=-=-=-=-=-";
        }
    }
}
