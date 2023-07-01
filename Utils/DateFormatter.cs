using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Utils
{
    public class DateFormatter
    
    {
        public static string DateToString(DateTime date) { 
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        public static DateTime StringToDate(string date)
        {
            string[] datetimeArray = date.Split(' ');
            string[] dateArray = datetimeArray[0].Split('/');
            int day = Convert.ToInt32(dateArray[0]);
            int month = Convert.ToInt32(dateArray[1]);
            int year = Convert.ToInt32(dateArray[2]);

            string[] timeArray = datetimeArray[1].Split(':');
            int hours = Convert.ToInt32(timeArray[0]);
            int minutes = Convert.ToInt32(timeArray[1]);
            return new DateTime(year, month, day, hours, minutes, 0);
        }
    }
}
