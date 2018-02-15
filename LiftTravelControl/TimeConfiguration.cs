namespace LiftTravelControl
{
    internal class TimeConfiguration : ITimeConfiguration
    {
        public int InMillisecondSeconds { get; private set; }

        public TimeConfiguration(int milliSec)
        {
            InMillisecondSeconds = milliSec;
        }
    }
}
