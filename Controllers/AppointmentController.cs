using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;
using VeterinaryClinic.Views;

namespace VeterinaryClinic.Controllers
{
    public class AppointmentController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Appointments.txt";

        public List<Appointment> List()
        {
            return DataSet.Appointments;
        }

        public List<Appointment> ListByClinic(int clinicId)
        {
            List<Appointment> appointments = new List<Appointment>();

            foreach (var appointment in DataSet.Appointments)
            {
                if (appointment.Clinic.Id == clinicId)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public bool Insert(Appointment appointment)
        {
            if (appointment == null)
                return false;

            if (appointment.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(appointment.Reason))
                return false;

            if (appointment.Date == null)
                return false;

            DataSet.Appointments.Add(appointment);

            return true;
        }

        public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;
            foreach (Appointment c in DataSet.Appointments)
            {
                fileContent += $"{c.Id};{c.Reason};{c.Date.ToString()};{c.AnimalId};{c.ClinicId}";
                fileContent += "\n";
            }

            try
            {
                StreamWriter sw = File.CreateText($"{directoryName}\\{fileName}");

                sw.Write(fileContent);
                sw.Close();
            }
            catch (IOException ioEx)
            {
                Messages.Error("Erro ao manipular o arquivo.");
                Messages.Error(ioEx.Message);
                return false;
            }

            return true;
        }

        public bool ImportFromTxtFile()
        {
            try
            {
                StreamReader sr = new StreamReader($"{directoryName}\\{fileName}");

                string line = string.Empty;
                line = sr.ReadLine();
                while (line != null)
                {
                    Appointment appointment = new Appointment();
                    string[] appointmentData = line.Split(';');
                    appointment.Id = Convert.ToInt32(appointmentData[0]);
                    appointment.Reason = appointmentData[1];
                    appointment.Date = DateTime.Parse(appointmentData[2]);
                    appointment.AnimalId = Convert.ToInt32(appointmentData[3]);
                    appointment.Animal = DataSet.Animals
                        .Where(animal => animal.Id == Convert.ToInt32(appointmentData[3]))
                        .FirstOrDefault();
                    appointment.ClinicId = Convert.ToInt32(appointmentData[4]);
                    appointment.Clinic = DataSet.Clinics
                        .Where(clinic => clinic.Id == Convert.ToInt32(appointmentData[4]))
                        .FirstOrDefault();

                    DataSet.Appointments.Add(appointment);

                    line = sr.ReadLine();
                }

                return true;
            }
            catch (Exception ex)
            {
                Messages.Error("Ooops. Ocorreu um erro ao tentar importar os dados.");
                Messages.Error(ex.Message);
                return false;
            }
        }

        public Appointment GetAppointmentById(int id)
        {
            if (id <= 0)
                return null;

            Appointment ret = new Appointment();
            foreach (var c in DataSet.Appointments)
            {
                if (c.Id == id)
                {
                    ret = c;
                    break;
                }
            }

            return ret;
        }

        public int GetNextId()
        {
            int length = DataSet.Appointments.Count;

            if (length > 0)
                return DataSet.Appointments[length - 1].Id + 1;
            else
                return 1;
        }
    }
}
