using LiftTravelControl.Interfaces;
using LiftTravelControl.Pocos;
using LiftTravelControl.Tests.Dummies;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LiftTravelControl.Tests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_MustOpensDoor_WhenSummonedOnCurrentFloor()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IDoor door = new Door(new TimeConfigurationSmallDelayDummyForTest());
            ILift lift = new Lift(floorConfig, door);

            lift.SummonCall(new SummonInformation(floorConfig.CurrentFloor, TravelDirection.Up));

            Assert.True(lift.IsOpen);
        }

        [Fact]
        public async Task Lift_MustStartTravelUpAfterRecieveInsedRequestForHigherFloorThanCurrentFloor_WhenDoorClose()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            Door door = new Door(new TimeConfigurationNoDelayDummyForTest());
            var fakeLift = new Mock<Lift>(floorConfig, door);
            fakeLift.Object.Initialize(floorConfig, door);

            await door.RequestClosing();
            
            fakeLift.Verify(lift => lift.StartTravel());
        }
    }
}
