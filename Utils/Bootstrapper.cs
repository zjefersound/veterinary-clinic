using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Utils
{
    public class Bootstrapper
    {
        public static void ChargeClinics()
        {
            DataSet.Clinics.Add(
                new Clinic
                {
                    Id = 1,
                    Name = "Bicho da maçã",
                    Email = "contato@bicho.com",
                }
            );
            DataSet.Clinics.Add(
                new Clinic
                {
                    Id = 2,
                    Name = "Furtado",
                    Email = "contato@furtado.com",
                }
            );
        }

        public static void ChargeClients()
        {
            DataSet.Clients.Add(
                new Client
                {
                    Id = 1,
                    FirstName = "Jeferson",
                    LastName = "Souza",
                    CPF = "000.000.000-01",
                    Email = "jiromel@gmail.com",
                    ClinicId = 1,
                    Clinic = DataSet.Clinics.Where(clinic => clinic.Id == 1).FirstOrDefault(),
                }
            );
            DataSet.Clients.Add(
                new Client
                {
                    Id = 2,
                    FirstName = "Dona",
                    LastName = "Lurde",
                    CPF = "000.000.000-02",
                    Email = "jiromel@gmail.com",
                    ClinicId = 1,
                    Clinic = DataSet.Clinics.Where(clinic => clinic.Id == 1).FirstOrDefault(),
                }
            );
            DataSet.Clients.Add(
                new Client
                {
                    Id = 3,
                    FirstName = "Seu",
                    LastName = "Aldair",
                    CPF = "000.000.000-03",
                    Email = "jiromel@gmail.com",
                    ClinicId = 2,
                    Clinic = DataSet.Clinics.Where(clinic => clinic.Id == 2).FirstOrDefault(),
                }
            );
        }

        public static void ChargeAnimals()
        {
            DataSet.Animals.Add(
                new Animal
                {
                    Id = 1,
                    Name = "Bilu",
                    Type = "Chachorro",
                    OwnerId = 2,
                    Owner = DataSet.Clients.Where(client => client.Id == 2).FirstOrDefault(),
                }
            );
        }
    }
}
