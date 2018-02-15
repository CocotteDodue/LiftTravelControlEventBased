using LiftTravelControl.Interfaces;
using Xunit;

namespace LiftTravelControl.Tests
{
    public partial class LiftTests
    {
        [Fact]
        public void Lift_CanaryTest()
        {
            FloorConfiguration floorConfig = new FloorConfiguration(3, 0, 15);
            IDoor door = new Door(null);

            ILift lift = new Lift(floorConfig, door);

            Assert.Equal(floorConfig.CurrentFloor, lift.CurrentFloor);
        }
        
    }
}
