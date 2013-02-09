using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using CodeCamp2013.WebApi.Models;

namespace CodeCamp2013.WebApi.Formatters
{
    public class EventCsvFormatter : BufferedMediaTypeFormatter
    {
        public EventCsvFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Event) || typeof(IEnumerable<Event>).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var events = value as IEnumerable<Event>;
                if (events != null)
                {
                    foreach (var evt in events)
                    {
                        writeItem(evt, writer);
                    }
                }
                else
                {
                    var evt = value as Event;
                    if (evt == null)
                    {
                        throw new InvalidOperationException("Cannot serialize this type");
                    }
                    writeItem(evt, writer);
                }
            }
        }

        private static void writeItem(Event evt, StreamWriter writer)
        {
            writer.WriteLine("{0},{1},{2},{3},{4},{5}", evt.ID, evt.Host, evt.Title, evt.Description, evt.StartDateTime, evt.Address);
        }
    }
}