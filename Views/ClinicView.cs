using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Controllers;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Views
{
    public class ClinicView
    {
        private ClinicController ClinicController;

        public ClinicView()
        {
            ClinicController = new ClinicController();
            this.Init();
        }

        public void Init()
        {
            Headings.Title("> CLÍNICAS");
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
            Headings.Title("> Lista de clínicas:");
            List<Clinic> listagem = ClinicController.List();

            for (int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }
            Messages.NeedsAction();
        }

        private string Print(Clinic Clinic)
        {
            string content = "";
            content += $"Id: {Clinic.Id} \n";
            content += $"Nome: {Clinic.Name} \n";
            content += "-------------------------------------------\n";

            return content;
        }

        private void Insert()
        {
            Headings.Title("> Nova clínica:");

            Clinic Clinic = new Clinic();

            Clinic.Id = ClinicController.GetNextId();

            Console.WriteLine("Informe o nome:");
            Clinic.Name = Console.ReadLine();

            Console.WriteLine("Informe o email:");
            Clinic.Email = Console.ReadLine();

            bool result = ClinicController.Insert(Clinic);

            if (result)
                Console.WriteLine("Clínica inserida com sucesso!");
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if (ClinicController.ExportToTextFile())
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Messages.Ops();
        }

        private void Import()
        {
            if (ClinicController.ImportFromTxtFile())
                Console.WriteLine("Dados importados com sucesso!");
            else
                Messages.Ops();
        }
    }
}
