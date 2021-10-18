using NUnit.Framework;
using System;
using System.Text;
using System.Text.Json;

namespace RMQ_Test
{
    public class RabbitMQTests
    {
        enum EventType
        {
            FrameworkPublished,
            Undetermined
        }

        private EventDto InterestingEvent = new EventDto { Event = "Framework_Published" };
        private EventDto UninterestingEvent = new EventDto { Event = "Some_Random_Stuff" };
        private EventDto EmptyEvent = new EventDto { Event = "" };
        private EventDto NullEvent = new EventDto { Event = null };
        bool OpenConnection;
        private string GoodString = "Tjena tjena! När är det Av?";
        private string EmptyString = "";
        private string NullString = null;

        [SetUp]
        public void Setup()
        {

        }
        
        // Event Determination

        [Test]
        [Description("Event Determination")]
        [Category("Event Handling")]
        public void Can_Determine_Interesting_Event()
        {
            var result = DetermineEvent(InterestingEvent);
            if (result == EventType.FrameworkPublished)
                Assert.Pass();
        }

        [Test]
        [Description("Event Determination")]
        [Category("Event Handling")]
        public void Can_Determine_UnInteresting_Event()
        {
            var result = DetermineEvent(UninterestingEvent);
            if (result == EventType.Undetermined)
                Assert.Pass();
        }

        [Test]
        [Description("Event Determination")]
        [Category("Event Handling")]
        public void Can_Determine_Empty_Event()
        {
            var result = DetermineEvent(EmptyEvent);
            if (result == EventType.Undetermined)
                Assert.Pass();
        }
        [Test]
        [Description("Event Determination")]
        [Category("Event Handling")]
        public void Can_Determine_Null_Event()
        {
            var result = DetermineEvent(NullEvent);
            if (result == EventType.Undetermined)
                Assert.Pass();
        }

        private EventType DetermineEvent(EventDto InMessage)
        {
            switch (InMessage.Event)
            {
                case "Framework_Published":
                    Console.WriteLine(" ==> Framework Event Detected");
                    return EventType.FrameworkPublished;
                default:
                    Console.WriteLine("==> Could not determine Event Type");
                    return EventType.Undetermined;
            }
        }
                                 // Event 
        public void PublishFramework(PersonPublishedFramework personPublishedFramework)
        {
            var message = JsonSerializer.Serialize(personPublishedFramework);

            if (OpenConnection)
            {
                SendMessage(message);
                Console.WriteLine("==> Rmq connection is open, sending message...");
            }
            else
            {
                Console.WriteLine("==> Rmq connection is closed, not sending");
            }
        }
        private byte[] SendMessage(string message)
        {
            if (message is not null)
            {
                var body = Encoding.UTF8.GetBytes(message);
                return body;
            }
            else
            {
                message = "";
                var body = Encoding.UTF8.GetBytes(message);
                return body;
            }
        }

        [Test]
        [Description("Event Publishing")]
        [Category("Event Handling")]
        public void Can_Send_Good_String()
        {
            var expected = Encoding.UTF8.GetBytes("hej");
            var actual = SendMessage("hej");
           
           Assert.That(actual, Is.EqualTo(expected));
           
        }
        [Test]
        [Description("Event Publishing")]
        [Category("Event Handling")]
        public void Can_Send_Empty_String()
        {
            var result = SendMessage(EmptyString);
            if (result is byte[])
            {
                Assert.Pass();
            }
        }
        [Test]
        [Description("Event Publishing")]
        [Category("Event Handling")]
        public void Can_Handle_Null_String()
        {
            var result = SendMessage(NullString);
            if (result is byte[])
            {
                Assert.Pass();
            }
        }
        public class PersonPublishedFramework
        {
            public Guid Id { get; set; }

            public string Framework { get; set; }

            public string Event { get; set; }
        }
        public class EventDto
        {
            public string Event { get; set; }
        }


    }
}