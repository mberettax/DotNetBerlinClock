using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public class ClockConfig
    {
        #region characters to represent lamps 

        public const char RedLamp = 'R';
        public const char YellowLamp = 'Y';

        #endregion

        #region number of lamps in clock rows

        public int BlinkLamps { get; private set; }
        public int HourLampsPerRow { get; private set; }
        public int MinuteLampsRow1 { get; private set; }
        public int MinuteLampsRow2 { get; private set; }

        #endregion

        #region number of lamps in clock rows

        public int NumberOfBlinksStates { get; private set; }
        public int HoursPerLampRow1 { get; private set; }
        public int MinutesPerLampRow1 { get; private set; }

        #endregion

        public ClockConfig(int blinkLamps,
            int hourLampsPerRow,
            int minuteLampsRow1,
            int minuteLampsRow2,
            int numberOfBlinkStates,
            int hoursPerLampRow1,
            int minutesPerLampRow1)
        {
            BlinkLamps = blinkLamps;
            HourLampsPerRow = hourLampsPerRow;
            MinuteLampsRow1 = minuteLampsRow1;
            MinuteLampsRow2 = minuteLampsRow2;
            NumberOfBlinksStates = numberOfBlinkStates;
            HoursPerLampRow1 = hoursPerLampRow1;
            MinutesPerLampRow1 = minutesPerLampRow1;
        }
    }
}
