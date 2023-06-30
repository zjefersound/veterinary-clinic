using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.Views
{
    public class DashboardView
    {
        public DashboardView()
        {
            this.Init();
        }

        public void Init()
        {
            int option = 0;
            do
            {
                Headings.Title("Gestão clinica veterinária:");
                Menu.PrintOptions(new List<string> { "Selecionar clínica", "Gestão de clínicas", });

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ManagementView managementView = new ManagementView();
                        break;
                    case 2:
                        ClinicView clinicView = new ClinicView();
                        break;
                }
            } while (option > 0);
        }
    }
}
