using LiftTravelControl.Poco;

namespace LiftTravelControl.Tests.Dummies
{
    internal class TimeConfigurationSmallDelayDummyForTest : TimeConfiguration
    {
        public TimeConfigurationSmallDelayDummyForTest() : base(50)
        {
        }
    }
}
