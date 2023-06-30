using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.Models
{

    public class Clinic
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Clinic()
        {

        }

        public Clinic(
            int id
            , string? name
            , string? cpf
            , string? email
        )
        {
            Id = id;
            Name = name;
            Email = email;
        }

    }

}