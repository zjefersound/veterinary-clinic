using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Controllers;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Views
{
    public class ClientView
    {
        private Clinic clinic;
        private ClientController clientController;

        public ClientView(Clinic clinic)
        {
            this.clinic = clinic;
            this.clientController = new ClientController();
            this.Init();
        }

        public void Init()
        {
            Headings.Title($"{this.clinic.Name} > CLIENTES");
            Menu.PrintOptions(new List<string> { "Inserir", "Listar", "Exportar", "Importar", "Pesquisar"});

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
                case 5:
                    SearchByName();
                    break;

                default:
                    break;
            }
        }

        private void List()
        {
            Headings.Title($"{this.clinic.Name} > Lista de clientes:");
            List<Client> list = clientController.ListByClinic(clinic.Id);

            if (list.Count <= 0)
            {
                Messages.Warn("Nenhum cliente foi encontrado");
                return;
            }

            foreach (Client item in list)
            {
                Console.WriteLine(Print(item));
            }
            Messages.NeedsAction();
        }

        private string Print(Client client)
        {
            string content = "";
            content += $"Id: {client.Id} \n";
            content += $"Nome: {client.FirstName} {client.LastName} \n";
            content += "-------------------------------------------\n";

            return content;
        }

        private void Insert()
        {
            Headings.Title("> Novo cliente:");

            Client client = new Client();

            client.Id = clientController.GetNextId();
            client.ClinicId = clinic.Id;

            Console.WriteLine("Informe o primeiro nome:");
            client.FirstName = Console.ReadLine();

            Console.WriteLine("Informe o sobrenome:");
            client.LastName = Console.ReadLine();

            Console.WriteLine("Informe o CPF:");
            client.CPF = Console.ReadLine();

            Console.WriteLine("Informe o email:");
            client.Email = Console.ReadLine();

            bool retorno = clientController.Insert(client);

            if (retorno)
                Messages.Success("Cliente inserido com sucesso!");
            else
                Messages.Warn("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if (clientController.ExportToTextFile())
                Messages.Success("Arquivo gerado com sucesso!");
            else
                Messages.Ops();
        }

        private void Import()
        {
            if (clientController.ImportFromTxtFile())
                Messages.Success("Dados importados com sucesso!");
            else
                Messages.Ops();
        }

        private void SearchByName()
        {
            Headings.Title($"{this.clinic.Name} > Pesquisar clientes:");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();

            List<Client> list = clientController.SearchByName(name, clinic.Id);

            if (list.Count <= 0)
            {
                Messages.Warn("Nenhum cliente foi encontrado");
                return;
            }

            foreach (Client item in list)
            {
                Console.WriteLine(Print(item));
            }
            Messages.NeedsAction();
        }
    }
}
