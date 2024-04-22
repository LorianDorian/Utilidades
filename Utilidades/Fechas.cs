using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Fechas
    {
        public static void CalculateTimeDifference(DateTime startDate, DateTime endDate, out int days, out int hours, out int minutes, out int seconds)
        {
            TimeSpan difference = endDate - startDate;

            // Calculate the total number of seconds
            long totalSeconds = (long)difference.TotalSeconds;

            // Calculate the number of days
            days = (int)(totalSeconds / (60 * 60 * 24));
            totalSeconds %= (60 * 60 * 24);

            // Calculate the number of hours
            hours = (int)(totalSeconds / (60 * 60));
            totalSeconds %= (60 * 60);

            // Calculate the number of minutes
            minutes = (int)(totalSeconds / 60);

            // Calculate the number of seconds
            seconds = (int)(totalSeconds % 60);
        }

        public static string GenerateTimeStamp()
        {
            // Get the current date and time
            DateTime now = DateTime.Now;

            // Format the date and time as a timestamp
            string timeStamp = now.ToString("yyyy-MM-dd HH:mm:ss");

            return timeStamp;
        }

        public class DateValidator
        {
            public static bool IsValidDate(string date)
            {
                if (string.IsNullOrEmpty(date))
                {
                    return false;
                }

                string[] parts = date.Split(new char[] { '-', '/' });
                if (parts.Length != 3)
                {
                    return false;
                }

                if (!int.TryParse(parts[0], out int year) || year < 1 || year > 9999)
                {
                    return false;
                }

                if (!int.TryParse(parts[1], out int month) || month < 1 || month > 12)
                {
                    return false;
                }

                if (!int.TryParse(parts[2], out int day) || day < 1 || day > DateTime.DaysInMonth(year, month))
                {
                    return false;
                }

                return true;
            }
        }

        public static string ConvertDateFormat(string inputDate, string outputFormat)
        {
            DateTime date;
            if (!DateTime.TryParse(inputDate, out date))
            {
                return "Invalid input date format. Please provide a valid date.";
            }

            if (outputFormat == "yyyy-MM-dd")
            {
                return date.ToString("yyyy-MM-dd");
            }
            else if (outputFormat == "dd/MM/yyyy")
            {
                return date.ToString("dd/MM/yyyy");
            }
            else if (outputFormat == "MMMM dd, yyyy")
            {
                return date.ToString("MMMM dd, yyyy");
            }
            else
            {
                return "Invalid output date format. Please specify a valid date format.";
            }
        }

    }
}
