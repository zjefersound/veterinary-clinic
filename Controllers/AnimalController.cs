using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;
using VeterinaryClinic.Views;

namespace VeterinaryClinic.Controllers
{
    public class AnimalController
    {
        // private string directoryName = "ReportFiles";
        // private string fileName = "Animals.txt";

        // public List<Animal> List()
        // {
        //     return DataSet.Animals;
        // }

        // public List<Animal> ListByClinic(int clinicId)
        // {
        //     List<Animal> animals = new List<Animal>();

        //     foreach (var animal in DataSet.Animals)
        //     {
        //         if (animal.ClinicId == clinicId)
        //         {
        //             animals.Add(animal);
        //         }
        //     }
        //     return animals;
        // }

        // public bool Insert(Animal animal)
        // {
        //     if (animal == null)
        //         return false;

        //     if (animal.Id <= 0)
        //         return false;

        //     if (string.IsNullOrWhiteSpace(animal.Name))
        //         return false;

        //     DataSet.Animals.Add(animal);

        //     return true;
        // }

        // public bool ExportToTextFile()
        // {
        //     if (!Directory.Exists(directoryName))
        //         Directory.CreateDirectory(directoryName);

        //     string fileContent = string.Empty;
        //     foreach (Animal c in DataSet.Animals)
        //     {
        //         fileContent += $"{c.Id};{c.CPF};{c.FirstName};{c.LastName};{c.Email};{c.ClinicId}";
        //         fileContent += "\n";
        //     }

        //     try
        //     {
        //         StreamWriter sw = File.CreateText($"{directoryName}\\{fileName}");

        //         sw.Write(fileContent);
        //         sw.Close();
        //     }
        //     catch (IOException ioEx)
        //     {
        //         Messages.Error("Erro ao manipular o arquivo.");
        //         Messages.Error(ioEx.Message);
        //         return false;
        //     }

        //     return true;
        // }

        // public bool ImportFromTxtFile()
        // {
        //     try
        //     {
        //         StreamReader sr = new StreamReader($"{directoryName}\\{fileName}");

        //         string line = string.Empty;
        //         line = sr.ReadLine();
        //         while (line != null)
        //         {
        //             Animal animal = new Animal();
        //             string[] animalData = line.Split(';');
        //             animal.Id = Convert.ToInt32(animalData[0]);
        //             animal.CPF = animalData[1];
        //             animal.FirstName = animalData[2];
        //             animal.LastName = animalData[3];
        //             animal.Email = animalData[4];
        //             animal.ClinicId = Convert.ToInt32(animalData[5]);

        //             DataSet.Animals.Add(animal);

        //             line = sr.ReadLine();
        //         }

        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         Messages.Error("Ooops. Ocorreu um erro ao tentar importar os dados.");
        //         Messages.Error(ex.Message);
        //         return false;
        //     }
        // }

        // public List<Animal> SearchByName(string name, int clinicId)
        // {
        //     if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        //         return null;

        //     List<Animal> animals = new List<Animal>();
        //     foreach (var animal in DataSet.Animals)
        //     {
        //         if (
        //             animal.ClinicId == clinicId
        //             && animal.FullName.ToLower().Contains(name.ToLower())
        //         )

        //             animals.Add(animal);
        //     }

        //     return animals;
        // }

        // public Animal GetAnimalById(int id)
        // {
        //     if (id <= 0)
        //         return null;

        //     Animal ret = new Animal();
        //     foreach (var c in DataSet.Animals)
        //     {
        //         if (c.Id == id)
        //         {
        //             ret = c;
        //             break;
        //         }
        //     }

        //     return ret;
        // }

        // public int GetNextId()
        // {
        //     int length = DataSet.Animals.Count;

        //     if (length > 0)
        //         return DataSet.Animals[length - 1].Id + 1;
        //     else
        //         return 1;
        // }
    }
}
