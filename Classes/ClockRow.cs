using System;
using System.Linq;

namespace BerlinClock
{
    /// <summary>
    /// clock row model
    /// </summary>
    public class ClockRow
    {
        /// <summary>
        /// filler for empty position in clock row
        /// </summary>
        const char EmptyValChar = 'O';

        /// <summary>
        /// lambda to compute appropriate lamp char
        /// </summary>
        public Func<int, char> ComputeLampChar { get; set; }

        /// <summary>
        /// defines whole length of clock row
        /// </summary>
        public int Length { private get; set; }

        /// <summary>
        /// defines how many lamps should be highlighted
        /// </summary>
        public int LampsOn { private get; set; }

        public override string ToString() =>
            string
                .Join(
                    string.Empty,
                    new string(
                        Enumerable.Range(0, LampsOn).Select(ComputeLampChar).ToArray()
                    )
                )
                .PadRight(Length, EmptyValChar);
    }
}
