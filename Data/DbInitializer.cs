using System;
using System.Linq;
using WebCityEvents.Data;
using WebCityEvents.Models;

namespace WebCityEvents
{
    public static class DbInitializer
    {
        public static void Initialize(EventContext context)
        {
            if (context.Customers.Any())
            {
                return;

                var customers = new Customer[]
                {
                new Customer { FullName = "Иван Иванов", PassportData = "1234567890" },
                new Customer { FullName = "Анна Смирнова", PassportData = "9876543210" }
                };
                context.Customers.AddRange(customers);

                var organizers = new Organizer[]
                {
                new Organizer { FullName = "Организатор А" },
                new Organizer { FullName = "Организатор Б" }
                };
                context.Organizers.AddRange(organizers);

                var events = new Event[]
                {
                new Event { EventName = "Концерт", Organizer = organizers[0], EventDate = DateTime.Now.AddDays(10), TicketPrice = 1000, TicketAmount = 100 },
                new Event { EventName = "Фестиваль", Organizer = organizers[1], EventDate = DateTime.Now.AddDays(20), TicketPrice = 1500, TicketAmount = 200 }
                };
                context.Events.AddRange(events);

                var ticketOrders = new TicketOrder[]
                {
                new TicketOrder { Customer = customers[0], Event = events[0], OrderDate = DateTime.Now, TicketCount = 2 },
                new TicketOrder { Customer = customers[1], Event = events[1], OrderDate = DateTime.Now, TicketCount = 1 }
                };
                context.TicketOrders.AddRange(ticketOrders);

                context.SaveChanges();
            }
        }
    }
}