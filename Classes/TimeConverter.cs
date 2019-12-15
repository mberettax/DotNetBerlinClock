namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private ClockConfig _config = new ClockConfig(
            blinkLamps: 1,
            hourLampsPerRow: 4,
            minuteLampsRow1: 11,
            minuteLampsRow2: 4,
            numberOfBlinkStates: 2,
            hoursPerLampRow1: 5,
            minutesPerLampRow1: 5);

        public string convertTime(string aTime)
        {
            var clock = new Clock(aTime, _config);

            return clock.ToString();
        }
    }
}
