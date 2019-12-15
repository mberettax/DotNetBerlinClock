using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    /// <summary>
    /// helper that convert time string time stamp
    /// </summary>
    public static class DateTimeUtilities
    {
        /// <summary>
        /// expected time string format
        /// </summary>
        private const string TimeFormat = "HH:mm:ss";
        
        /// <summary>
        /// template to check if string defines 24th hour
        /// </summary>
        private const string TimeTemplate = @"24(:[0-5][0-9]:[0-5][0-9])$";

        /// <summary>
        /// adjusts time string so it could be converted to timespan
        /// </summary>
        /// <param name="val">time string</param>
        /// <returns></returns>
        private static string Adjust(this string val) =>
            Regex.Replace(val, TimeTemplate, "00$1");

        /// <summary>
        /// parses formatted time string to timestamp
        /// </summary>
        /// <param name="val">time string</param>
        /// <returns></returns>
        private static TimeSpan ParseFormattedTimeString(this string val) =>
            DateTime.ParseExact(val, TimeFormat, CultureInfo.CurrentCulture).TimeOfDay;

        /// <summary>
        /// parses time string to timespan.
        /// hours overflow is taken into consideration.
        /// </summary>
        /// <param name="val">time string</param>
        /// <returns></returns>
        public static TimeSpan ParseTimeString(this string val) =>
            Regex.IsMatch(val, TimeTemplate)
                ? val.Adjust().ParseFormattedTimeString().Add(TimeSpan.FromDays(1))
                : val.ParseFormattedTimeString();
    }
}
