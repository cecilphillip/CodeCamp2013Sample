using System;
using System.Collections.Generic;
using System.Linq;
using CodeCamp2013.WebApi.SelfHost.Data;
using CodeCamp2013.WebApi.SelfHost.Models;

namespace CodeCamp2013.WebApi.SelfHost
{
    public class EventsService : IEventsService
    {
        private readonly IRepository<Event> eventsRepo;

        public EventsService(IRepository<Event> repo)
        {
            this.eventsRepo = repo;
        }

        public IEnumerable<Event> GetEvents()
        {
            var results = this.eventsRepo.All().ToList();
            return results;
        }

        public IEnumerable<Event> GetPastEvents()
        {
            var results = this.eventsRepo.Find(evt => evt.StartDateTime < DateTime.Now).ToList();
            return results;
        }

        public IEnumerable<Event> GetUpcomingEvents()
        {
            var results = this.eventsRepo.Find(evt => evt.StartDateTime > DateTime.Now).ToList();
            return results;
        }

        public IEnumerable<Event> SearchEvent(string searchTerm)
        {
            var results = this.eventsRepo.Find(evt => evt.Title.Contains(searchTerm) || evt.Description.Contains(searchTerm)).ToList();
            return results;
        }

        public Event GetEventByID(int eventID)
        {
            var result = this.eventsRepo.FindSingle(evt => evt.ID == eventID);
            return result;
        }
    }
}