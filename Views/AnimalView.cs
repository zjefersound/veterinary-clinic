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
        // private Clinic clinic;
        // private AnimalController animalController;
        // private ClientController clientController;

        // public AnimalView(Clinic clinic)
        // {
        //     this.clinic = clinic;
        //     this.animalController = new AnimalController();
        //     this.Init();
        // }

        // public void Init()
        // {
        //     Headings.Title($"{this.clinic.Name} > ANIMAIS");
        //     Menu.PrintOptions(new List<string> { "Inserir", "Listar", "Exportar", "Importar", "Pesquisar"});

        //     int option = 0;
        //     option = Convert.ToInt32(Console.ReadLine());

        //     switch (option)
        //     {
        //         case 1:
        //             Insert();
        //             break;

        //         case 2:
        //             List();
        //             break;

        //         case 3:
        //             Export();
        //             break;

        //         case 4:
        //             Import();
        //             break;
        //         case 5:
        //             SearchByName();
        //             break;

        //         default:
        //             break;
        //     }
        // }

        // private void List()
        // {
        //     Headings.Title($"{this.clinic.Name} > Lista de animales:");
        //     List<Animal> list = animalController.ListByClinic(clinic.Id);

        //     if (list.Count <= 0)
        //     {
        //         Messages.Warn("Nenhum animale foi encontrado");
        //         return;
        //     }

        //     foreach (Animal item in list)
        //     {
        //         Console.WriteLine(Print(item));
        //     }
        //     Messages.NeedsAction();
        // }

        // private string Print(Animal animal)
        // {
        //     string content = "";
        //     content += $"Id: {animal.Id} \n";
        //     content += $"Nome: {animal.FirstName} {animal.LastName} \n";
        //     content += "-------------------------------------------\n";

        //     return content;
        // }

        // private void Insert()
        // {
        //     Headings.Title("> Novo animale:");

        //     Animal animal = new Animal();

        //     animal.Id = animalController.GetNextId();
        //     animal.ClinicId = clinic.Id;

        //     Console.WriteLine("Informe o primeiro nome:");
        //     animal.FirstName = Console.ReadLine();

        //     Console.WriteLine("Informe o sobrenome:");
        //     animal.LastName = Console.ReadLine();

        //     Console.WriteLine("Informe o CPF:");
        //     animal.CPF = Console.ReadLine();

        //     Console.WriteLine("Informe o email:");
        //     animal.Email = Console.ReadLine();

        //     bool retorno = animalController.Insert(animal);

        //     if (retorno)
        //         Messages.Success("Animale inserido com sucesso!");
        //     else
        //         Messages.Warn("Falha ao inserir, verifique os dados!");
        // }

        // private void Export()
        // {
        //     if (animalController.ExportToTextFile())
        //         Messages.Success("Arquivo gerado com sucesso!");
        //     else
        //         Messages.Ops();
        // }

        // private void Import()
        // {
        //     if (animalController.ImportFromTxtFile())
        //         Messages.Success("Dados importados com sucesso!");
        //     else
        //         Messages.Ops();
        // }

        // private void SearchByName()
        // {
        //     Headings.Title($"{this.clinic.Name} > Pesquisar animales:");
        //     Console.WriteLine("Digite o nome:");
        //     string name = Console.ReadLine();

        //     List<Animal> list = animalController.SearchByName(name, clinic.Id);

        //     if (list.Count <= 0)
        //     {
        //         Messages.Warn("Nenhum animale foi encontrado");
        //         return;
        //     }

        //     foreach (Animal item in list)
        //     {
        //         Console.WriteLine(Print(item));
        //     }
        //     Messages.NeedsAction();
        // }
    }
}
