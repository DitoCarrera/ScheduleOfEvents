

using EventScheduler.Model.Entities;
using System.Diagnostics.Tracing;
using System.Globalization;

Console.WriteLine("BEM VINDO A AGENDA DE EVENTOS!!!");

EventCalendar events = new EventCalendar(); 
Event @event = null;
List<Event> eventsFind = null;
Boolean exit = false;

while (!exit)
{
    
    try {
        Console.WriteLine("\nOpções: ");
        Console.WriteLine("[ 1 ] Add");
        Console.WriteLine("[ 2 ] Find");
        Console.WriteLine("[ 3 ] Remove");
        Console.WriteLine("[ 4 ] GetEventsForDate");
        Console.WriteLine("[ 5 ] SortEvents");
        Console.WriteLine("[ 6 ] Exit");
        Console.Write("Escolha sua opção: ");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.Write("Title: ");
                string title = Console.ReadLine();
                Console.Write("Description: ");
                string description = Console.ReadLine();
                Console.WriteLine("Location: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("City: ");
                string city = Console.ReadLine();   
                Console.Write("State: ");
                string state = Console.ReadLine();
                Console.Write("PostalCode: ");
                string postalCode = Console.ReadLine();
                Console.Write("StartDate: ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("EndDate: ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                @event = new Event(title, description, new Location(name, address, city, state, postalCode), startDate, endDate);

                events.AddEvent(@event);
          
                break;
            case 2:
                Console.WriteLine("Title: ");
                title = Console.ReadLine();
                Console.Write("StartDate (dd/MM/yyyy HH:mm): ");
                startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                events.FindEvent(title, startDate);
                break;

            case 3:
                Console.WriteLine("Title: ");
                title = Console.ReadLine();
                Console.Write("StartDate (dd/MM/yyyy): ");
                startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                events.RemoveEvent(title, startDate);
                break;

            case 4:
                Console.Write("StartDate (dd/MM/yyyy): ");
                startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                eventsFind = events.GetEventsForDate(startDate);

                foreach (Event eve in eventsFind)
                {
                    Console.WriteLine(eve);
                }
                break;
            case 5:

                int number = 0;
                eventsFind = events.SortEvents(number);

                foreach (Event eve in eventsFind)
                {
                    Console.WriteLine(eve);
                }

                break;
            case 6:
                exit = true;
                break;
            default:
                throw new ArgumentException("Wrong option");
                break;
        }
        Console.WriteLine("");


    }
    catch (InvalidOperationException e) {
        Console.WriteLine(e.Message);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
}