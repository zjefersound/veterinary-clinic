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
        private ClientController clientController;

        public ClientView()
        {
            clientController = new ClientController();
            this.Init();
        }

        public void Init()
        {
            Headings.Title("> CLIENTES");
            Menu.PrintOptions(new List<string> { "Inserir", "Listar", "Exportar", "Importar", });

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
            List<Client> list = clientController.List();

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
    }
}
