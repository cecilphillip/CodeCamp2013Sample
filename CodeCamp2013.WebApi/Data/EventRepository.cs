using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CodeCamp2013.WebApi.Models;

namespace CodeCamp2013.WebApi.Data
{
    public class EventRepository : IRepository<Event>
    {
        protected EventsDemoContext context;

        public EventRepository(EventsDemoContext ctx)
        {
            this.context = ctx;
        }

        public IQueryable<Event> All()
        {
            return context.Events;
        }

        public void InsertOrUpdate(Event entity)
        {
            if (entity.ID == default(int))
            {
                context.Events.Add(entity);
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var entity = context.Events.Find(id);
            context.Events.Remove(entity);
        }

        public IQueryable<Event> Find(Expression<Func<Event, bool>> exp)
        {
            return this.context.Events.Where(exp);
        }

        public Event FindSingle(Expression<Func<Event, bool>> exp)
        {
            return this.context.Events.SingleOrDefault(exp);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}