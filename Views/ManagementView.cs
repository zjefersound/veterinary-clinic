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
        private Clinic currentClinic;
        private ClinicController clinicController;

        public ManagementView()
        {
            this.currentClinic = null;
            this.clinicController = new ClinicController();
            this.Init();
        }

        public void Init()
        {
            this.SelectClinic();
            this.ManageClinic();
        }

        public void SelectClinic()
        {
            bool isClinicSelected =
                this.currentClinic != null && Convert.ToBoolean(this.currentClinic.Id);
            while (!isClinicSelected)
            {
                Headings.Title("Selecionar clínica");

                List<Clinic> list = clinicController.List();

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
                    return;

                this.currentClinic = clinicController.GetClinicById(option);

                if (Convert.ToBoolean(this.currentClinic.Id))
                {
                    Messages.Success($"Clínica Selecionada: {this.currentClinic.Name}");
                    break;
                }
                Messages.Warn("Clínica Inválida");
            }
        }

        public void ManageClinic()
        {
            bool isClinicSelected =
                this.currentClinic != null && Convert.ToBoolean(this.currentClinic.Id);
            if (!isClinicSelected)
                return;

            int option = 0;
            do
            {
                Headings.Title($"CLÍNICA: {currentClinic.Name}");
                Console.WriteLine("O que você deseja fazer?");
                Menu.PrintOptions(new List<string> { "Clientes", "Animais", "Consultas", });
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ClientView clientView = new ClientView(currentClinic);
                        break;
                    case 2:
                        AnimalView animalView = new AnimalView(currentClinic);
                        break;
                    // case 3:
                    //     ClientView clientView = new ClientView();
                    //     break;
                }
            } while (option > 0);
        }
    }
}
