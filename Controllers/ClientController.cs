using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using VeterinaryClinic.Data;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Controllers
{
    public class ClientController
    {
      private string directoryName = "ReportFiles";
      private string fileName = "Clients.txt";

      public List<Client> List()
      {
          return DataSet.Clients;
      }

    }
}