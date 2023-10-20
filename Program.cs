namespace Budweg
{
    using System;

    class Program
    {
        static string[] evacuationList = new string[100];
        static string[] employeeNumbers = new string[100];
        static string[] adminNumbers = new string[100];
        static int evacuationListCount = 0;
        static int employeeNumbersCount = 0;
        static int adminNumbersCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear(); 

                Console.WriteLine("Hello and welcome to your registration!");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Guest");
                Console.WriteLine("3. Admin");
                Console.WriteLine("4. Evacuation List");
                Console.Write("Press 1, 2, 3, or 4: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CheckInAsEmployee();
                            break;
                        case 2:
                            CheckInAsGuest();
                            break;
                        case 3:
                            CheckInAsAdmin();
                            break;
                        case 4:
                            ViewEvacuationList();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void CheckInAsEmployee()
        {
            Console.Clear();
            Console.WriteLine("Check in as an employee:");

            while (true)
            {
                Console.WriteLine("1. Check in");
                Console.WriteLine("2. Check out");
                Console.WriteLine("3. Update your information");
                Console.WriteLine("4. Back to the start menu");
                Console.Write("Choose an action (1-4): ");

                int employeeChoice;
                if (int.TryParse(Console.ReadLine(), out employeeChoice))
                {
                    switch (employeeChoice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Check in as an employee:");
                            Console.Write("Enter ID: ");
                            string employeeID = Console.ReadLine();

                            if (Array.Exists(employeeNumbers, x => x == employeeID))
                            {
                                Console.WriteLine($"You are now checked in and working at workstation \"x\" in zone.");
                            }
                            else
                            {
                                Console.WriteLine("The entered ID number is not in the system. Please try again.");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You are now checked out.");
                            return; // Back to the main menu
                        case 3:
                            UpdateEmployeeInformation();
                            break;
                        case 4:
                            return; // Back to the admin menu
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void UpdateEmployeeInformation()
        {
            Console.Clear();
            Console.WriteLine("Update your information:");

            // Implement the logic for updating employee information
        }

        static void CheckInAsGuest()
        {
            Console.Clear();
            Console.WriteLine("Check in as a guest:");

            // Implement the logic for guests
        }

        static void CheckInAsAdmin()
        {
            Console.Clear();
            Console.WriteLine("Check in as an admin:");

            while (true)
            {
                Console.WriteLine("1. Evacuation List");
                Console.WriteLine("2. Employee Competencies");
                Console.WriteLine("3. Register Employee");
                Console.WriteLine("4. Register Admin");
                Console.WriteLine("5. Check in");
                Console.WriteLine("6. Back to the main menu");
                Console.Write("Choose an action (1-6): ");

                int adminChoice;
                if (int.TryParse(Console.ReadLine(), out adminChoice))
                {
                    switch (adminChoice)
                    {
                        case 1:
                            ViewEvacuationList();
                            break;
                        case 2:
                            ViewEmployeeCompetencies();
                            break;
                        case 3:
                            RegisterEmployee();
                            break;
                        case 4:
                            RegisterAdmin();
                            break;
                        case 5:
                            Console.WriteLine("You are now checked in.");
                            return; // Back to the main menu
                        case 6:
                            return; // Back to the main menu
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void ViewEmployeeCompetencies()
        {
            Console.Clear();
            Console.WriteLine("Employee Competencies:");
            // Implement displaying employee competencies
        }

        static void RegisterEmployee()
        {
            Console.Clear();
            Console.WriteLine("Register Employee:");
            // Implement registering employees
        }

        static void RegisterAdmin()
        {
            Console.Clear();
            Console.WriteLine("Register Admin:");

            string firstName, lastName;
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();

            // Simulate assigning an admin number based on first name and last name
            string adminNumber = $"{firstName.Substring(0, 1)}{lastName.Substring(0, 1)}{adminNumbersCount + 1}";
            adminNumbers[adminNumbersCount++] = adminNumber;

            Console.WriteLine($"{firstName} {lastName}, your admin number is: {adminNumber}");
        }

        static void ViewEvacuationList()
        {
            Console.Clear();
            Console.WriteLine("Evacuation List:");
            // Implement displaying the evacuation list
        }
    }
}
