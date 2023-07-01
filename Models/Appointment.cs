using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int AnimalId { get; set; }
        public int ClinicId { get; set; }
        public Animal Animal { get; set; }
        public Clinic Clinic { get; set; }
    }
}
