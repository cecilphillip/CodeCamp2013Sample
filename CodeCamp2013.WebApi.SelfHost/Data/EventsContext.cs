using System.Data.Entity;
using CodeCamp2013.WebApi.SelfHost.Models;

namespace CodeCamp2013.WebApi.SelfHost.Data
{
    public class EventsDemoContext : DbContext
    {
        public IDbSet<Event> Events { get; set; }
    }
}