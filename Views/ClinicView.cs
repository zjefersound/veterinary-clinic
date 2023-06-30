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
        private ClinicController clinicController;

        public ClinicView()
        {
            this.clinicController = new ClinicController();
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
            List<Clinic> list = clinicController.List();

            foreach (Clinic item in list)
            {
                Console.WriteLine(Print(item));
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

            Clinic.Id = clinicController.GetNextId();

            Console.WriteLine("Informe o nome:");
            Clinic.Name = Console.ReadLine();

            Console.WriteLine("Informe o email:");
            Clinic.Email = Console.ReadLine();

            bool result = clinicController.Insert(Clinic);

            if (result)
                Messages.Success("Clínica inserida com sucesso!");
            else
                Messages.Warn("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if (clinicController.ExportToTextFile())
                Messages.Success("Arquivo gerado com sucesso!");
            else
                Messages.Ops();
        }

        private void Import()
        {
            if (clinicController.ImportFromTxtFile())
                Messages.Success("Dados importados com sucesso!");
            else
                Messages.Ops();
        }
    }
}
