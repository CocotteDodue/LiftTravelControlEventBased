using LiftTravelControl.Interfaces;
using LiftTravelControl.Tests.Dummies;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LiftTravelControl.Tests
{
    public partial class LiftTest
    {
        [Fact]
        public void Lift_CanStartTravel_WhenDoorIsClosed()
        {
            var fakeDoor = new Mock<IDoor>();
            fakeDoor
                .Setup(door => door.IsOpen)
                .Returns(false);
            ILift lift = new Lift(null, fakeDoor.Object);

            bool travelStarted = lift.StartTravel();

            Assert.True(travelStarted);
        }

        [Fact]
        public void Lift_CannotStartTravel_WhenDoorIsOpen()
        {
            var fakeDoor = new Mock<IDoor>();
            fakeDoor
                .Setup(door => door.IsOpen)
                .Returns(true);
            ILift lift = new Lift(null, fakeDoor.Object);

            bool travelStarted = lift.StartTravel();

            Assert.False(travelStarted);
        }

        //[Fact]
        //public Task Lift_MustNotStartTravelIfNoCallLeft_WhenDoorClose()
        //{
        //    FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
        //    IDoor door = new Door(new TimeConfigurationNoDelayDummyForTest());
        //    var fakeLift = new Mock<Lift>(floorConfig, door);

        //    door.RequestClosing();

        //    fakeLift.Verify(lift => lift.StartTravel());
        //}
    }
}
