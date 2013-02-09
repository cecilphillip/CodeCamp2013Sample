using System.Data.Entity;
using CodeCamp2013.WebApi.Models;

namespace CodeCamp2013.WebApi.Data
{
    public class EventsDemoContext : DbContext
    {
        public IDbSet<Event> Events { get; set; }
    }
}