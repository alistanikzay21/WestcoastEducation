using WestcoastEducation.Enums;
using WestcoastEducation.Models;

class Program
{
    static List<Course> courses = new();
    static List<Student> students = new();

    static void Main()
    {
        bool running = true;
        
        while (running)
        {
            Console.WriteLine("\n=== Westcoast Education ===");
            Console.WriteLine("1. Lägg till kurs");
            Console.WriteLine("2. Lista kurser");
            Console.WriteLine("3. Lägg till student");
            Console.WriteLine("4. Lista studenter");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj alternativ: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddCourse();
                    break;

                case "2":
                    ListCourses();
                    break;

                case "3":
                    AddStudent();
                    break;

                case "4":
                    ListStudents();
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

    static void AddCourse()
    {
        Console.WriteLine("\n--- Lägg till kurs ---");

        Console.Write("Kursnummer: ");
        string courseNumber = ReadRequiredText();

        Console.Write("Kursnamn: ");
        string title = ReadRequiredText();

        Console.Write("Längd i antal veckor eller dagar: ");
        int length;

        while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.Write("Ange ett positivt heltal: ");
        }

         Console.Write("Ange 1 för veckor eller 2 för dagar: ");
        string unitChoice = Console.ReadLine() ?? "";

        while (unitChoice != "1" && unitChoice != "2")
        {
            Console.Write("Välj 1 för veckor eller 2 för dagar: ");
            unitChoice = Console.ReadLine() ?? "";
        }

         LengthUnitEnum lengthUnit;

        if (unitChoice == "1")

        {
            lengthUnit = LengthUnitEnum.Weeks;
        }

        else

        {
            lengthUnit = LengthUnitEnum.Days;
        }

         Console.Write("Ange 1 för klassrum eller 2 för distans: ");
        string typeChoice = Console.ReadLine() ?? "";

        while (typeChoice != "1" && typeChoice != "2")
        {
            Console.Write("Välj 1 för klassrum eller 2 för distans: ");
            typeChoice = Console.ReadLine() ?? "";
        }

         CourseTypeEnum courseType;

        if (typeChoice == "1")
        {
            courseType = CourseTypeEnum.Classroom;
        }
        else
        {
            courseType = CourseTypeEnum.Distance;
        }

        
    }    
}