using System.Collections.Generic;
using CodeCamp2013.WebApi.Models;

namespace CodeCamp2013.WebApi
{
    public interface IEventsService
    {
        IEnumerable<Event> GetEvents();
        IEnumerable<Event> GetPastEvents();
        IEnumerable<Event> GetUpcomingEvents();
        IEnumerable<Event> SearchEvent(string searchTerm);
        Event GetEventByID(int eventID);

        void AddEvent(Event newEvent);
    }
}