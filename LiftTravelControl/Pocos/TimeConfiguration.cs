namespace LiftTravelControl.Poco

{
    internal class TimeConfiguration
    {
        public int InMillisecondSeconds { get; set; }

        public TimeConfiguration(int milliSec)
        {
            InMillisecondSeconds = milliSec;
        }
    }
}
