using Xunit;

namespace LiftTravelControl.Tests
{
    public class LiftTests
    {
        [Fact]
        public void Lift_CanaryTest()
        {
            int currentFloor = 3;
            int lowestFloor = 0;
            int highestFloor = 15;
            ILift lift = new Lift(currentFloor, lowestFloor, highestFloor);

            Assert.Equal(currentFloor, lift.CurrentFloor);
            Assert.Equal(lowestFloor, lift.MinFloor);
            Assert.Equal(highestFloor, lift.MaxFloor);
        }
    }
}
