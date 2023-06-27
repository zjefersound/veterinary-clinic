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
                Console.WriteLine("===========================");
                Console.WriteLine("Gestão clinica veterinária:");
                Console.WriteLine("===========================");
                Console.WriteLine("");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Selecionar clínica");
                Console.WriteLine("2 - Gestão de clínicas");


                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("OPÇÃO CLIENTES");
                        ClientView clientView = new ClientView();
                        break;
                }
            }
            while (option > 0);
        }
    }
}