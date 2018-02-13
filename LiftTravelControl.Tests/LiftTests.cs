﻿using LiftTravelControl.Exceptions;
using System;
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

        [Fact]
        public void Lift_MustThrowArgumentException_WhenCurrentFloorOutsideBoundaryFloors()
        {
            int currentFloor = 15;
            int lowestFloor = 0;
            int highestFloor = 9;

            Assert.Throws<UnknowFloorExecption>(() => new Lift(currentFloor, lowestFloor, highestFloor));
        }

        [Fact]
        public void Lift_MustThrowArgumentException_WhenGroundFloorHigherThanTopFloor()
        {
            int currentFloor = 5;
            int lowestFloor = 10;
            int highestFloor = 1;

            Assert.Throws<ArgumentException>(() => new Lift(currentFloor, lowestFloor, highestFloor));
        }
    }
}
