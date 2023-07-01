using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Controllers;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Views
{
    public class AppointmentView
    {
        private Clinic clinic;
        private AppointmentController appointmentController;
        private AnimalController animalController;

        public AppointmentView(Clinic clinic)
        {
            this.clinic = clinic;
            this.appointmentController = new AppointmentController();
            this.animalController = new AnimalController();
            this.Init();
        }

        public void Init()
        {
            Headings.Title($"{this.clinic.Name} > CONSULTAS");
            Menu.PrintOptions(new List<string> { "Agendar", "Listar", "Exportar", "Importar", });

            int option = 0;
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Insert();
                    break;

                case 2:
                    List();
                    break;

                // case 3:
                //     Export();
                //     break;

                // case 4:
                //     Import();
                //     break;

                default:
                    break;
            }
        }

        private void List()
        {
            Headings.Title($"{this.clinic.Name} > Próximas consultas:");
            List<Appointment> list = appointmentController.ListByClinic(clinic.Id);

            if (list.Count <= 0)
            {
                Messages.Warn("Nenhuma consulta foi encontrada");
                return;
            }

            foreach (Appointment item in list)
            {
                Console.WriteLine(Print(item));
            }
            Messages.NeedsAction();
        }

        private string Print(Appointment appointment)
        {
            string content = "";
            content += $"Id: {appointment.Id} \n";
            content += $"Motivo: {appointment.Reason} \n";
            content += $"Animal: {appointment.Animal.Name} \n";
            content += $"Dono: {appointment.Animal.Owner.FullName} \n";
            content += $"Data: {appointment.Date.ToString()} \n";
            content += "-------------------------------------------\n";

            return content;
        }

        private void Insert()
        {
            Headings.Title("> Nova consulta:");

            Appointment appointment = new Appointment();

            appointment.Id = appointmentController.GetNextId();
            appointment.ClinicId = clinic.Id;
            appointment.Clinic = clinic;

            Console.WriteLine("Pesquisar animal por nome:");
            string name = Console.ReadLine();

            List<Animal> animals;

            if (string.IsNullOrWhiteSpace(name))
                animals = animalController.ListByClinic(clinic.Id);
            else
                animals = animalController.SearchByName(name, clinic.Id);

            Console.WriteLine("Selecione o animal:");

            if (animals.Count <= 0)
            {
                Messages.Warn("Nenhum animal foi encontrado");
                return;
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"({animal.Id}) {animal.Name} | Dono: {animal.Owner.FullName} ");
            }

            int animalId = Convert.ToInt32(Console.ReadLine());

            appointment.AnimalId = animalId;
            appointment.Animal = animalController.GetAnimalById(animalId);

            if (appointment.Animal.Id == null)
            {
                Messages.Warn("Animal inválido!");
                return;
            }

            Console.WriteLine("Informe o motivo da consulta:");
            appointment.Reason = Console.ReadLine();

            Console.WriteLine("Informe a data (Ex: 01/01/2000):");
            string date = Console.ReadLine();

            Console.WriteLine("Selecione o horário:");
            Menu.PrintOptions(new List<string> { "9:00", "11:00", "13:00", "15:00" });
            int timeOption = Convert.ToInt32(Console.ReadLine());

            if (timeOption <= 0 || timeOption > 4)
            {
                Messages.Warn("Consulta cancelada");
            }

            Console.WriteLine(DateTime.Now);
 
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime)) 
                Console.WriteLine("The specified date is valid: " + dateTime);
            
            else 
                Console.WriteLine("Unable to parse the specified date");
            
            appointment.Date = DateTime.Now;


            bool retorno = appointmentController.Insert(appointment);

            if (retorno)
                Messages.Success("Appointment inserido com sucesso!");
            else
                Messages.Warn("Falha ao inserir, verifique os dados!");
        }

        // private void Export()
        // {
        //     if (appointmentController.ExportToTextFile())
        //         Messages.Success("Arquivo gerado com sucesso!");
        //     else
        //         Messages.Ops();
        // }

        // private void Import()
        // {
        //     if (appointmentController.ImportFromTxtFile())
        //         Messages.Success("Dados importados com sucesso!");
        //     else
        //         Messages.Ops();
        // }
    }
}
