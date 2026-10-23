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

        }
    }


}