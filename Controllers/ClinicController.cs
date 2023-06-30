using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Controllers
{
    public class ClinicController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Clinics.txt";

        public List<Clinic> List()
        {
            return DataSet.Clinics;
        }

        public bool Insert(Clinic Clinic)
        {
            if (Clinic == null)
                return false;

            if (Clinic.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(Clinic.Name))
                return false;

            DataSet.Clinics.Add(Clinic);

            return true;
        }

        public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;
            foreach (Clinic c in DataSet.Clinics)
            {
                fileContent += $"{c.Id};{c.Name};{c.Email}";
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
                Console.WriteLine("Erro ao manipular o arquivo.");
                Console.WriteLine(ioEx.Message);
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
                    Clinic Clinic = new Clinic();
                    string[] ClinicData = line.Split(';');
                    Clinic.Id = Convert.ToInt32(ClinicData[0]);
                    Clinic.Name = ClinicData[1];
                    Clinic.Email = ClinicData[2];

                    DataSet.Clinics.Add(Clinic);

                    line = sr.ReadLine();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooops. Ocorreu um erro ao tentar importar os dados.");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Clinic GetClinicById(int id)
        {
            if (id <= 0)
                return null;

            Clinic ret = new Clinic();
            foreach (var c in DataSet.Clinics)
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
            int length = DataSet.Clinics.Count;

            if (length > 0)
                return DataSet.Clinics[length - 1].Id + 1;
            else
                return 1;
        }
    }
}
