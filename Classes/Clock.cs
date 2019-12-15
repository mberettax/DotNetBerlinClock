using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    /// <summary>
    /// clock model
    /// </summary>
    public class Clock
    {
        /// <summary>
        /// time that should be converted
        /// </summary>
        private readonly TimeSpan _time;
        private readonly ClockConfig _clockConfig;

        /// <summary>
        /// clock state
        /// </summary>
        private List<ClockRow> Rows => new List<ClockRow>
            {
                new ClockRow
                {
                    ComputeLampChar = x => ClockConfig.YellowLamp,
                    Length = _clockConfig.BlinkLamps,
                    LampsOn = _time.Seconds % _clockConfig.NumberOfBlinksStates == 0 ? 1 : 0
                },
                new ClockRow
                {
                    ComputeLampChar = x => ClockConfig.RedLamp,
                    Length = _clockConfig.HourLampsPerRow,
                    LampsOn = (int)(_time.TotalHours - _time.TotalHours % _clockConfig.HoursPerLampRow1) / _clockConfig.HoursPerLampRow1
                },
                new ClockRow
                {
                    ComputeLampChar = x => ClockConfig.RedLamp,
                    Length = _clockConfig.HourLampsPerRow,
                    LampsOn = (int)_time.TotalHours % _clockConfig.HoursPerLampRow1
                },
                new ClockRow
                {
                    ComputeLampChar = x => (x + 1) % 3 == 0 ? ClockConfig.RedLamp : ClockConfig.YellowLamp,
                    Length = _clockConfig.MinuteLampsRow1,
                    LampsOn = (_time.Minutes - _time.Minutes % _clockConfig.MinutesPerLampRow1) / _clockConfig.MinutesPerLampRow1
                },
                new ClockRow
                {
                    ComputeLampChar = x => ClockConfig.YellowLamp,
                    Length = _clockConfig.MinuteLampsRow2,
                    LampsOn = _time.Minutes % _clockConfig.MinutesPerLampRow1
                }
            };

        /// <summary>
        /// clock model
        /// </summary>
        /// <param name="time">time that should be converted</param>
        public Clock(TimeSpan time, ClockConfig config)
        {
            _time = time;
            _clockConfig = config;
        }

        public Clock(string serializedTime, ClockConfig config)
            : this(serializedTime.ParseTimeString(), config)
        {

        }

        public override string ToString() => string.Join(Environment.NewLine, Rows.Select(x => x.ToString()));
    }
}
