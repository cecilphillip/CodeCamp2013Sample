using System.Linq;
using System.Net;
using System.Net.Http;
using CodeCamp2013.WebApi.Api;
using CodeCamp2013.WebApi.Models;
using FakeItEasy;
using Xunit;

namespace CodeCamp2013.WebApi.Tests
{
    public class EventsControllerTests
    {

        [Fact]
        public void GetEvents_Sets_Correct_Status_When_Empty()
        {
            //Arrange
            var eventsService = A.Fake<IEventsService>();
            A.CallTo(() => eventsService.GetEvents()).Returns(Enumerable.Empty<Event>());
            var controller = new EventsController(eventsService);
            WebApiTestHelper.SetupController(controller, "events/list");

            //Act
            var response = controller.GetEvents();

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public void GetEvents_Sets_Correct_Status_When_Data_Available()
        {
            //Arrange
            var eventsService = A.Fake<IEventsService>();
            A.CallTo(() => eventsService.GetEvents()).Returns(EventTestData.MultipleEvents);
            var controller = new EventsController(eventsService);
            WebApiTestHelper.SetupController(controller, "events/list");

            //Act
            var response = controller.GetEvents();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void CreateEvent_Sets_Correct_Status_When_Model_Null()
        {
            //Arrange
            var eventService = A.Fake<IEventsService>();
            var controller = new EventsController(eventService);
            WebApiTestHelper.SetupController(controller, "events/createEvent");

            //Act
            var response = controller.CreateEvent(null);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public void CreateEvent_Returns_Event_With_Uri()
        {
            //Arrange
            var newEvent = new Event
            {
                Title = "New Event"
            };
            var eventService = A.Fake<IEventsService>();
            A.CallTo(() => eventService.AddEvent(A<Event>.Ignored)).Invokes(x =>
                {
                    var evt = x.GetArgument<Event>("newEvent");
                    evt.ID = 1;
                });
            var controller = new EventsController(eventService);
            WebApiTestHelper.SetupController(controller, "events/createEvent");

            //Act
            var response = controller.CreateEvent(newEvent);
            var eventContent = response.Content.ReadAsAsync<Event>().Result;

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(newEvent, eventContent);
            Assert.True(response.Headers.Location.AbsoluteUri.EndsWith("eventID=" + eventContent.ID));
        }

    }
}
