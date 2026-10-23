using WestcoastEducation.Services;

namespace WestcoastEducation;

class Program
{
    static void Main()
    {
        EducationService educationService = new();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Westcoast Education ===");
            Console.WriteLine("1. Lägg till kurs");
            Console.WriteLine("2. Lista kurser");
            Console.WriteLine("3. Lägg till student");
            Console.WriteLine("4. Lista studenter");
            Console.WriteLine("5. Lägg till lärare");
            Console.WriteLine("6. Lista lärare");
            Console.WriteLine("7. Lägg till utbildningsledare");
            Console.WriteLine("8. Lista utbildningsledarna");
            Console.WriteLine("9. Lägg till administratör");
            Console.WriteLine("10. Lista administratörer");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj alternativ: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    educationService.AddCourse();
                    break;
                case "2":
                    educationService.ListCourses();
                    break;
                case "3":
                    educationService.AddStudent();
                    break;
                case "4":
                    educationService.ListStudents();
                    break;
                case "5":
                    educationService.AddTeacher();
                    break;
                case "6":
                    educationService.ListTeachers();
                    break;
                case "7":
                    educationService.AddEducationManager();
                    break;
                case "8":
                    educationService.ListEducationManagers();
                    break;
                case "9":
                    educationService.AddAdministrator();
                    break;
                case "10":
                    educationService.ListAdministrators();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Programmet avslutas.");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }
}