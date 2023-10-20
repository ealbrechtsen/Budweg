using System.Net;
using System.Runtime.ConstrainedExecution;

namespace Budweg_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vi har nået at implementere admin check in. Et simpelt defaultadmin login med id "1234" og password "1234".
            //Vi har implementeret registering af ansat gennem admin. Informationer om ansat oplyses af admin og gemmes i .txt via 

            //Her defineres en liste over admin-ID'er. I dette tilfælde er der kun én "defaultadmin"
            string[] adminIDs = new string[] { "1234" };

            // Vi opretter et RegistrationSystem-objekt, der sørger for registrering og check ind/check ud-processen
            // og så angiver vi kapaciteten for employee, guest og admin
            RegistrationSystem registrationSystem = new RegistrationSystem(300, 100, 50, adminIDs);

            while (true)
            {
                Console.Clear();

                //startmenuen
                Console.WriteLine("Hej og velkommen til din registrering!\n");
                Console.WriteLine("1. Ansat");
                Console.WriteLine("2. Gæst");
                Console.WriteLine("3. Admin");
                Console.WriteLine("4. Evakueringsliste");
                Console.WriteLine("5. Afslut");
                Console.Write("Tryk 1-5: ");

                //brugerens valg gemmes som int
                int choice = int.Parse(Console.ReadLine());

                //switch statement til at udføre handling på brugerens valg
                switch (choice)
                {
                    case 1:
                        registrationSystem.RegisterEmployee();
                        break;
                    case 2:
                        registrationSystem.RegisterGuest();
                        break;
                    case 3:
                        AdminMenu(registrationSystem, adminIDs);
                        break;
                    case 4:
                        registrationSystem.DisplayEvacuationList();
                        break;
                    case 5:
                        // Environment.Exit bruges til at exit menuen. Ikke bruge "return"; i Main-metoden,
                        // for det vil blot returnere fra Main-metoden til programmet,
                        // men programmet fortsætter med at køre
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        break;
                }

                Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        //Her defineres AdminMenu-metoden, som bruges til at håndtere admin-menuen og dens funktioner
        static void AdminMenu(RegistrationSystem registrationSystem, string[] adminIDs)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin-menu:\n");

                //Opretteren liste over muligheder i admin-menuen.

                string[] adminMenuOptions = { "Check in", "Check out", "Afslut Admin-menu" };
                int adminMenuChoice = DisplayMenu(adminMenuOptions);

                switch (adminMenuChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Admin-Check in:");
                        Console.Write("Indtast ID: ");
                        string enteredID = Console.ReadLine();

                        Console.Write("Indtast password: ");
                        string enteredPassword = Console.ReadLine();

                        if (adminIDs.Contains(enteredID) && enteredPassword == "1234")
                        {
                            Console.WriteLine("Velkommen, admin!");
                            AdminLoggedInMenu(registrationSystem, adminIDs);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldig ID eller adgangskode. Prøv igen eller afslut.");
                        }

                        Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                        Console.ReadKey();
                        break;
                    case 1:
                        // Implementer Check out-logik her
                        Console.WriteLine("Du har valgt Check out.");
                        break;
                    case 2:
                        Console.WriteLine("Afslutter Admin-menuen.");
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        break;
                }

                Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        //Her er AdminLoggedInMenu-metoden, der håndterer menuen for admin, når de er logget ind.
        static void AdminLoggedInMenu(RegistrationSystem registrationSystem, string[] adminIDs)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin-menu:\n");

                string[] adminMenuOptions = { "Opdater din information", "Evakuerings liste", "Registrer admin", "Registrer ansat", "Ansatte kompetencer", "Afslut" };
                int adminMenuChoice = DisplayMenu(adminMenuOptions);

                switch (adminMenuChoice)
                {
                    case 0:
                        Console.WriteLine("Du har valgt at opdatere din information.");
                        break;
                    case 1:
                        registrationSystem.DisplayEvacuationList();
                        break;
                    case 2:
                        Console.WriteLine("Du har valgt at registrere en admin.");
                        break;
                    case 3:
                        Console.WriteLine("Du har valgt at registrere en ansat.");
                        Console.Clear();
                        Console.WriteLine("Registrer ansat:\n");

                        Console.Write("Fornavn: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Efternavn: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Alder: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Tlf. nr.: ");
                        string phoneNumber = Console.ReadLine();

                        Console.Write("E-mail: ");
                        string email = Console.ReadLine();

                        // Mangelr at finde et måde at genere et unikt ID-nummer og password
                        string employeeID = "1234";

                        // Generer et 1234 password for den ansatte
                        string employeePassword = "1234";


                        Employee newEmployee = new Employee(firstName, lastName, age, phoneNumber, email, employeeID, employeePassword);

                        try
                        {
                            using (StreamWriter writer = new StreamWriter("employee_data.txt", true))
                            {
                                writer.WriteLine($"{newEmployee.FirstName}, {newEmployee.LastName}, {newEmployee.Age}, {newEmployee.PhoneNumber}, {newEmployee.Email}");
                            }

                            Console.WriteLine("Ansat er blevet registreret og oplysninger er gemt.");
                        }
                        catch (IOException a)
                        {
                            Console.WriteLine($"Der opstod en fejl, da vi prøvede at gemme dine oplysninger: {a.Message}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Du har valgt at se ansattes kompetencer.");
                        break;
                    case 5:
                        Console.WriteLine("Afslutter Admin-menuen.");
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        break;
                }

                Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        //viser en menu med valgmuligheder og lader brugeren vælge en mulighed.
        static int DisplayMenu(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {       //  Udskriver hver mulighed i menuen med en numerisk reference (1, 2, 3 osv)
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.Write($"Tryk 1-{options.Length}: "); //brugeren kan indtaste et valg mellem 1 og flere muligheder
            int choice = int.Parse(Console.ReadLine()) - 1; //Læser brugerens valg som en streng,
                                                            //konverterer det til et heltal og trækker 1 for at få
                                                            //den korrekte position

            if (choice < 0 || choice >= options.Length) // er valget gyldigt?
            {
                Console.WriteLine("Ugyldigt valg.");
                return -1;
            }

            return choice;

        }
    }
}

