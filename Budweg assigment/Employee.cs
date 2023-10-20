using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Budweg_2._0
{
    //Her defineres en Employee klasse, der repræsenterer de ansatte i systemet
    public class Employee
    {
        //der ses forskellige properties der gemmer informationer på den ansatte
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsCheckedIn { get; set; }

        //Constructor der opretter et nyt Employee-objekt
        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
            IsCheckedIn = false;
        }

        // properties til at gemme oplysninger om den ansatte
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // ID og password
        public string ID { get; set; }
        public string Password { get; set; }

        // Constructor til at oprette et nyt Employee-objekt
        public Employee(string firstName, string lastName, int age, string phoneNumber, string email, string id, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            ID = id;
            Password = password;

        }
    }
}
