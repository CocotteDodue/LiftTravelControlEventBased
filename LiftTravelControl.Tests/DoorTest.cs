using LiftTravelControl.Events;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LiftTravelControl.Tests
{
    public class DoorTest
    {
        [Fact]
        public void Door_IsOpenMustBeFalse_WhenIsClose()
        {
            IDoor door = new Door(null);
            Assert.False(door.IsOpen);
        }

        [Fact]
        public void Door_MustSetIsOpenToTrue_WhenIsCloseAndRequestOpening()
        {
            ITimeConfiguration timeConfig = new TimeConfiguration(50);
            IDoor door = new Door(timeConfig);

            door.RequestOpening();

            Assert.True(door.IsOpen);
        }

        [Fact]
        public void Door_MustNotify_WhenStartOpening()
        {
            ITimeConfiguration timeConfig = new TimeConfiguration(50);
            IDoor door = new Door(timeConfig);
            IList<DoorMovmentEventArgs> receivedEvents = new List<DoorMovmentEventArgs>();
            EventHandler<DoorMovmentEventArgs> del = delegate (object sender, DoorMovmentEventArgs e)
            {
                receivedEvents.Add(e);
            };
            door.SubscribeToDoorMovmentEvents(del);

            door.RequestOpening();
            
            Assert.True(receivedEvents.First().IsOpen);
            door.UnsubscribeToDoorMovmentEvents(del);
        }

        [Fact]
        public async Task Door_MustNotify_WhenClosed()
        {
            ITimeConfiguration timeConfig = new TimeConfiguration(50);
            IDoor door = new Door(timeConfig);
            IList<DoorMovmentEventArgs> receivedEvents = new List<DoorMovmentEventArgs>();
            EventHandler<DoorMovmentEventArgs> del = delegate (object sender, DoorMovmentEventArgs e)
            {
                receivedEvents.Add(e);
            };
            door.SubscribeToDoorMovmentEvents(del);

            await door.RequestClosing();

            Assert.Equal(1, receivedEvents.Count);
            Assert.False(receivedEvents.Last().IsOpen);
            door.UnsubscribeToDoorMovmentEvents(del);
        }

        [Fact]
        public async Task Door_MustCloseAutomatically_AfterOpening()
        {
            ITimeConfiguration timeConfig = new TimeConfiguration(50);
            IDoor door = new Door(timeConfig);
            IList<DoorMovmentEventArgs> receivedEvents = new List<DoorMovmentEventArgs>();
            EventHandler<DoorMovmentEventArgs> del = delegate (object sender, DoorMovmentEventArgs e)
            {
                receivedEvents.Add(e);
            };
            door.SubscribeToDoorMovmentEvents(del);

            await door.RequestOpening();

            Assert.Equal(2, receivedEvents.Count);
            Assert.False(receivedEvents.Last().IsOpen);
            door.UnsubscribeToDoorMovmentEvents(del);
        }
    }
}
