using LiftTravelControl.Events;
using LiftTravelControl.Interfaces;
using LiftTravelControl.Poco;
using LiftTravelControl.Tests.Dummies;
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
            TimeConfiguration timeConfig = new TimeConfigurationNoDelayDummyForTest();
            IDoor door = new Door(timeConfig);

            door.RequestOpening();

            Assert.True(door.IsOpen);
        }

        [Fact]
        public void Door_MustNotify_WhenStartOpening()
        {
            TimeConfiguration timeConfig = new TimeConfigurationNoDelayDummyForTest();
            IDoor door = new Door(timeConfig);
            IList<DoorMovmentEventArgs> receivedEvents = new List<DoorMovmentEventArgs>();
            EventHandler<DoorMovmentEventArgs> del = delegate (object sender, DoorMovmentEventArgs e)
            {
                receivedEvents.Add(e);
            };
            door.SubscribeToDoorMovmentEvents(del);

            door.RequestOpening();
            
            Assert.False(receivedEvents.First().HasClosed);
            door.UnsubscribeToDoorMovmentEvents(del);
        }

        [Fact]
        public async Task Door_MustNotify_WhenClosed()
        {
            TimeConfiguration timeConfig = new TimeConfigurationNoDelayDummyForTest();
            IDoor door = new Door(timeConfig);
            IList<DoorMovmentEventArgs> receivedEvents = new List<DoorMovmentEventArgs>();
            EventHandler<DoorMovmentEventArgs> del = delegate (object sender, DoorMovmentEventArgs e)
            {
                receivedEvents.Add(e);
            };
            door.SubscribeToDoorMovmentEvents(del);

            await door.RequestClosing();

            Assert.Equal(1, receivedEvents.Count);
            Assert.True(receivedEvents.Last().HasClosed);
            door.UnsubscribeToDoorMovmentEvents(del);
        }

        [Fact]
        public async Task Door_MustCloseAutomatically_AfterOpening()
        {
            TimeConfiguration timeConfig = new TimeConfigurationNoDelayDummyForTest();
            IDoor door = new Door(timeConfig);
            IList<DoorMovmentEventArgs> receivedEvents = new List<DoorMovmentEventArgs>();
            EventHandler<DoorMovmentEventArgs> del = delegate (object sender, DoorMovmentEventArgs e)
            {
                receivedEvents.Add(e);
            };
            door.SubscribeToDoorMovmentEvents(del);

            await door.RequestOpening();

            Assert.Equal(2, receivedEvents.Count);
            Assert.True(receivedEvents.Last().HasClosed);
            door.UnsubscribeToDoorMovmentEvents(del);
        }
    }
}
