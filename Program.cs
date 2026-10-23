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
    }    
}