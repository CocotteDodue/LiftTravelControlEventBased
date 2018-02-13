namespace LiftTravelControl.Extensions
{
    internal static class IntegerExtensions
    {
        public static bool IsValidFloor(this int currentFloor, int min, int max)
        { 
            return currentFloor >= min && currentFloor <= max;
        }
    }
}
