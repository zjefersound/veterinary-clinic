using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;
using VeterinaryClinic.Controllers;

namespace VeterinaryClinic.Views
{
    public class ManagementView
    {
        private Clinic CurrentClinic;
        private ClinicController ClinicController;

        public ManagementView()
        {
            this.CurrentClinic = null;
            ClinicController = new ClinicController();
            this.Init();
        }

        public void Init()
        {
            while (CurrentClinic == null)
            {
                Headings.Title("Selecionar clínica");

                List<Clinic> list = ClinicController.List();

                if (list.Count <= 0)
                {
                    Messages.Warn("Nenhuma clínica foi encontrada");
                    return;
                }
                Console.WriteLine("Escolha a clinica pelo id:");
                Menu.PrintExit();
                foreach (Clinic item in list)
                {
                    Console.WriteLine($"({item.Id}) {item.Name}");
                }
                
                int option = 0;
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 0)
                    break;

                this.CurrentClinic = ClinicController.GetClinicById(option);
                if (this.CurrentClinic)
                    Messages.Success($"Clínica Selecionada: {this.CurrentClinic.Name}");
                else
                    Messages.Warn("Clínica Inválida");
            }
            this.ManageClinic();
        }

        public void ManageClinic()
        {
            int option = 0;
            do
            {
                Headings.Title("SUA CLINICA");
                Menu.PrintOptions(new List<string> { "Clientes", "Animais", "Consultas", });
            } while (option > 0);
        }
    }
}
