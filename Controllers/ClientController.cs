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
    public class ClientController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Clients.txt";

        public List<Client> List()
        {
            return DataSet.Clients;
        }

        public List<Client> ListByClinic(int clinicId)
        {
            List<Client> clients = new List<Client>();

            foreach (var client in DataSet.Clients)
            {
                if (client.ClinicId == clinicId)
                {
                    clients.Add(client);
                }
            }
            return clients;
        }

        public bool Insert(Client client)
        {
            if (client == null)
                return false;

            if (client.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(client.FirstName))
                return false;

            DataSet.Clients.Add(client);

            return true;
        }

        public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;
            foreach (Client c in DataSet.Clients)
            {
                fileContent += $"{c.Id};{c.CPF};{c.FirstName};{c.LastName};{c.Email};{c.ClinicId}";
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
                    Client client = new Client();
                    string[] clientData = line.Split(';');
                    client.Id = Convert.ToInt32(clientData[0]);
                    client.CPF = clientData[1];
                    client.FirstName = clientData[2];
                    client.LastName = clientData[3];
                    client.Email = clientData[4];
                    client.ClinicId = Convert.ToInt32(clientData[5]);
                    client.Clinic = DataSet.Clinics.Where(clinic => clinic.Id == Convert.ToInt32(clientData[5])).FirstOrDefault();

                    DataSet.Clients.Add(client);

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

        public List<Client> SearchByName(string name, int clinicId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return null;

            List<Client> clients = new List<Client>();
            foreach (var client in DataSet.Clients)
            {
                if (
                    client.ClinicId == clinicId
                    && client.FullName.ToLower().Contains(name.ToLower())
                )

                    clients.Add(client);
            }

            return clients;
        }

        public int GetNextId()
        {
            int length = DataSet.Clients.Count;

            if (length > 0)
                return DataSet.Clients[length - 1].Id + 1;
            else
                return 1;
        }

        public Client GetClientById(int id) {
            Client client = new Client();
            client = DataSet.Clients.Where(client => client.Id == id).FirstOrDefault();
            return client;
        }
    }
}
