using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Controllers;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Views
{
    public class AnimalView
    {
        private Clinic clinic;
        private AnimalController animalController;
        private ClientController clientController;

        public AnimalView(Clinic clinic)
        {
            this.clinic = clinic;
            this.animalController = new AnimalController();
            this.clientController = new ClientController();
            this.Init();
        }

        public void Init()
        {
            Headings.Title($"{this.clinic.Name} > ANIMAIS");
            Menu.PrintOptions(
                new List<string> { "Inserir", "Listar", "Exportar", "Importar" }
            );

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

                case 3:
                    Export();
                    break;

                case 4:
                    Import();
                    break;

                default:
                    break;
            }
        }

        private void List()
        {
            Headings.Title($"{this.clinic.Name} > Lista de animais:");
            List<Animal> list = animalController.ListByClinic(clinic.Id);

            if (list.Count <= 0)
            {
                Messages.Warn("Nenhum animal foi encontrado");
                return;
            }

            foreach (Animal item in list)
            {
                Console.WriteLine(Print(item));
            }
            Messages.NeedsAction();
        }

        private string Print(Animal animal)
        {
            string content = "";
            content += $"Id: {animal.Id} \n";
            content += $"Nome: {animal.Name} \n";
            content += $"Dono: {animal.Owner.FullName} \n";
            content += "-------------------------------------------\n";

            return content;
        }

        private void Insert()
        {
            Headings.Title("> Novo animal:");

            Animal animal = new Animal();

            animal.Id = animalController.GetNextId();

            Console.WriteLine("Selecione o dono:");

            List<Client> clients = clientController.ListByClinic(clinic.Id);

            if (clients.Count <= 0)
            {
                Messages.Warn("Nenhum cliente foi encontrado");
                return;
            }

            foreach (Client client in clients)
            {
                Console.WriteLine($"({client.Id}) {client.FullName}");
            }

            int ownerId = Convert.ToInt32(Console.ReadLine());
            animal.OwnerId = ownerId;
            animal.Owner = clientController.GetClientById(ownerId);
            if (animal.Owner.Id == null)
            {
                Messages.Warn("Dono inválido!");
                return;
            }

            Console.WriteLine("Informe o nome do animal:");
            animal.Name = Console.ReadLine();

            Console.WriteLine("Informe o tipo (cachorro, gato, tucano...):");
            animal.Type = Console.ReadLine();

            bool retorno = animalController.Insert(animal);

            if (retorno)
                Messages.Success("Animal inserido com sucesso!");
            else
                Messages.Warn("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if (animalController.ExportToTextFile())
                Messages.Success("Arquivo gerado com sucesso!");
            else
                Messages.Ops();
        }

        private void Import()
        {
            if (animalController.ImportFromTxtFile())
                Messages.Success("Dados importados com sucesso!");
            else
                Messages.Ops();
        }
    }
}
