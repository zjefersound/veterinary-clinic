using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.Models
{

    public class Client
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public Client()
        {

        }

        public Client(
            int id
            , string? firstName
            , string? lastName
            , string? cpf
            , string? email
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cpf;
            Email = email;
        }

        public string FullName => 
            $"{this.FirstName} {this.LastName}";


        public override string ToString()
        {   
            return $"Id: {this.Id}; Name: {this.FullName} ";
        }

    }

}