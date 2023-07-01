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
        public static string DateToString(DateTime date) { }

        public static string StringToDate(string date)
        {
            string[] appointmentData = line.Split('/');
            int day = Convert.ToInt32(appointmentData[0]);
            int month = Convert.ToInt32(appointmentData[0]);
            int year = Convert.ToInt32(appointmentData[0]);
        }
    }
}
