using System.Collections.Generic;
using CodeCamp2013.WebApi.SelfHost.Models;

namespace CodeCamp2013.WebApi.SelfHost
{
    public interface IEventsService
    {
        IEnumerable<Event> GetEvents();
        IEnumerable<Event> GetPastEvents();
        IEnumerable<Event> GetUpcomingEvents();
        IEnumerable<Event> SearchEvent(string searchTerm);
        Event GetEventByID(int eventID);
    }
}