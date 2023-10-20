using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg_2._0
{
    public class RegistrationSystem
    {
        private Employee[] employees;
        private Guest[] guests;
        private Admin[] admins;
        private string[] adminIDs;

        public RegistrationSystem(int employeeCapacity, int guestCapacity, int adminCapacity, string[] adminIDs)
        {
            this.employees = new Employee[employeeCapacity];
            this.guests = new Guest[guestCapacity];
            this.admins = new Admin[adminCapacity];
            this.adminIDs = adminIDs;
        }


        public void RegisterEmployee()
        {
            // Implementer registrering af ansatte her
        }

        public void RegisterGuest()
        {
            // Implementer registrering af gæster her
        }

        public void RegisterAdmin()
        {
            // Implementer registrering af administratorer her
        }

        public void CheckInOut()
        {
            // Implementer check-ind/check-ud-processen her
        }

        public void DisplayEvacuationList()
        {
            // Implementer visning af evakueringslisten her
        }
    }
}
