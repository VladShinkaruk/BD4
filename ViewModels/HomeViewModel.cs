using System.Collections.Generic;

namespace WebCityEvents.ViewModels
{
    public class HomeViewModel
    {
        public List<EventViewModel> Events { get; set; }
        public List<TicketOrderViewModel> TicketOrders { get; set; }
        public List<CustomerViewModel> Customers { get; set; }
    }
}