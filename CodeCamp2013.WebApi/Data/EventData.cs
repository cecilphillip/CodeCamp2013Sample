using System.Data.Entity;

namespace CodeCamp2013.WebApi.Data
{
    public static class EventData
    {
        public static void Initialize()
        {
            Database.SetInitializer(new EventsDemoSeedInitializer());
        }
    }
}