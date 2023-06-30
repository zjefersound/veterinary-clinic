using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        public int OwnerId { get; set; }

        public Client Owner => new Client();
    }
}
