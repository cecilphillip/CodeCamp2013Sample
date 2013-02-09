using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeCamp2013.WebApi.Filters;
using CodeCamp2013.WebApi.Models;

namespace CodeCamp2013.WebApi.Api
{
    [Logger]
    [ExceptionLogger]
    public class EventsController : ApiController
    {
        private readonly IEventsService eventService;

        //public EventsController()
        //{
        //    this.repo = new EventRepository();
        //}

        public EventsController(IEventsService repo)
        {
            this.eventService = repo;
        }

        [ActionName("list")]
        public HttpResponseMessage GetEvents()
        {
            //throw new InvalidOperationException();
            var results = eventService.GetEvents();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("byid")]
        public HttpResponseMessage GetEventByID(int eventID)
        {
            var result = this.eventService.GetEventByID(eventID);
            if (result != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("past")]
        public HttpResponseMessage GetPastEvents()
        {
            var results = eventService.GetPastEvents();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("upcoming")]
        public HttpResponseMessage GetUpcomingEvents()
        {
            var results = eventService.GetUpcomingEvents();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("search")]
        [HttpGet]
        public HttpResponseMessage SearchEventTitle(string searchTerm)
        {
            var results = eventService.SearchEvent(searchTerm);
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public HttpResponseMessage CreateEvent(Event newEvent)
        {
            if (newEvent == null) 
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException("newEvent"));

            try
            {
                eventService.AddEvent(newEvent);
                var response = Request.CreateResponse(HttpStatusCode.Created, newEvent);
                response.Headers.Location = new Uri(Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority + "/api/events/byid?eventID=" + newEvent.ID);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);                
            }
        }
    }
}
