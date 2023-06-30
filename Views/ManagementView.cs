using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.Views
{
    public class ManagementView
    {
        public ManagementView()
        {
            this.Init();
        }

        public void Init()
        {
            int option = 0;
            do
            {
                Headings.Title("SUA CLINICA");
                Menu.PrintOptions(new List<string> { "Clientes", "Animais", "Consultas", });

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Selecionar clínica...");
                        ClientView clientView = new ClientView();
                        break;
                    case 2:
                        Console.WriteLine("Gestão de clínicas...");
                        ClinicView clinicView = new ClinicView();
                        break;
                }
            } while (option > 0);
        }
    }
}
