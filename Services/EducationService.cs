using WestcoastEducation.Enums;
using WestcoastEducation.Models;

namespace WestcoastEducation.Services;

public class EducationService
{
    private readonly List<Course> courses = new();
    private readonly List<Student> students = new();
    private readonly List<Teacher> teachers = new();
    private readonly List<EducationManager> educationManagers = new();
    private readonly List<Administrator> administrators = new();

    public void AddCourse()
    {
        Console.WriteLine("\n--- Lägg till kurs ---");

        string courseNumber = ReadRequiredText("Kursnummer: ");
        string title = ReadRequiredText("Kursnamn: ");

        int length;

        Console.Write("Kurslängd i antal veckor eller dagar: ");

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
            lengthUnit = LengthUnitEnum.Week;
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

        DateOnly startDate = ReadDate("Startdatum (ÅÅÅÅ-MM-DD): ");
        DateOnly endDate;

        do
        {
            endDate = ReadDate("Slutdatum (ÅÅÅÅ-MM-DD): ");

            if (endDate < startDate)
            {
                Console.WriteLine("Slutdatumet får inte vara före startdatumet.");
            }
        }
        while (endDate < startDate);

        Course course = new()
        {
            CourseNumber = courseNumber,
            Titel = title,
            Length = length.ToString(),
            LengthUnit = lengthUnit,
            CourseType = courseType,
            StartDate = startDate,
            EndDate = endDate
        };

        courses.Add(course);

        Console.WriteLine("Kursen har lagts till!");
    }

    public void ListCourses()
    {
        Console.WriteLine("\n--- Kurser ---");

        if (courses.Count == 0)
        {
            Console.WriteLine("Det finns inga kurser att visa.");
            return;
        }

        foreach (Course course in courses)
        {
            Console.WriteLine();
            Console.WriteLine(course);
        }
    }

    public void AddStudent()
    {
        Console.WriteLine("\n--- Lägg till student ---");

       Person person = ReadPersonInformation();

        Student student = new()
        {
            PersonalInformation = person
        };

        students.Add(student);

        Console.WriteLine("Studenten har lagts till!");
    }

    public void ListStudents()
    {
        Console.WriteLine("\n--- Studenter ---");

        if (students.Count == 0)
        {
            Console.WriteLine("Det finns inga studenter att visa.");
            return;
        }

        foreach (Student student in students)
        {
            Console.WriteLine();
            Console.WriteLine(student);
        }
    }

     public void AddTeacher()

    {
        Console.WriteLine("\n--- Lägg till lärare ---");

        Person person = ReadPersonInformation();

        string knowledgeArea = ReadRequiredText("Kunskapsområde: ");

        Teacher teacher = new()
        {
            PersonalInformation = person,
            KnowledgeArea = knowledgeArea
        };

        teachers.Add(teacher);

        Console.WriteLine("Läraren har lagts till!");
    }

    public void ListTeachers()
    {
        Console.WriteLine("\n--- Lärare ---");

        if (teachers.Count == 0)
        {
            Console.WriteLine("Det finns inga lärare att visa.");
            return;
        }

        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine();
            Console.WriteLine(teacher);
        }
    }

    public void AddEducationManager()
    {
         Console.WriteLine("\n--- Lägg till utbildningsledare ---");

        Person person = ReadPersonInformation();

        string knowledgeArea = ReadRequiredText("Kunskapsområde: ");

        DateOnly employmentDate = ReadDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ");

        Teacher teacher = new()
        {
        PersonalInformation = person,
        KnowledgeArea = knowledgeArea
        };

        EducationManager educationManager = new()
        {

        TeacherInformation = teacher,
        EmploymentDate = employmentDate
        };

        educationManagers.Add(educationManager);

        Console.WriteLine("Utbildningsledaren har lagts till!");
    }
    public void ListEducationManagers()
    {

    Console.WriteLine("\n--- Utbildningsledarna ---");

    if (educationManagers.Count == 0)

    {
        Console.WriteLine("Det finns inga utbildningsledarna att visa.");
        return;
    }

    foreach (EducationManager educationManager in educationManagers)

    {
        Console.WriteLine();
        Console.WriteLine(educationManager);
    }
}
    public void AddAdministrator()
{
    Console.WriteLine("\n--- Lägg till administratör ---");

    Person person = ReadPersonInformation();

    string knowledgeArea = ReadRequiredText("Kunskapsområde: ");

    DateOnly employmentDate = ReadDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ");

    Teacher teacher = new()
    {
        PersonalInformation = person,
        KnowledgeArea = knowledgeArea
    };

    EducationManager educationManager = new()
    {
        TeacherInformation = teacher,
        EmploymentDate = employmentDate
    };

    Administrator administrator = new()
    {
        EducationManagerInformation = educationManager
    };

    administrators.Add(administrator);

    Console.WriteLine("Administratören har lagts till!");
}

    public void ListAdministrators()
{
    Console.WriteLine("\n--- Administratörer ---");

    if (administrators.Count == 0)
    {
        Console.WriteLine("Det finns inga administratörer att visa.");
        return;
    }

    foreach (Administrator administrator in administrators)
    {
        Console.WriteLine();
        Console.WriteLine(administrator);
    }
}
    private static Person ReadPersonInformation()
{
    return new Person
    {
        FirstName = ReadRequiredText("Förnamn: "),
        LastName = ReadRequiredText("Efternamn: "),
        PhoneNumber = ReadRequiredText("Telefonnummer: "),
        PersonalNumber = ReadRequiredText("Personnummer: "),
        Adress = ReadRequiredText("Adress: "),
        PostalCode = ReadRequiredText("Postnummer: "),
        City = ReadRequiredText("Ort: ")
    };
}
    private static string ReadRequiredText(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write("Fältet får inte vara tomt. Försök igen: ");
            input = Console.ReadLine();
        }

        return input;
    }
    private static DateOnly ReadDate(string prompt)
    {
        DateOnly date;

        Console.Write(prompt);

        while (!DateOnly.TryParse(Console.ReadLine(), out date))
        {
            Console.Write("Ogiltigt datum. Försök igen (ÅÅÅÅ-MM-DD): ");
        }

        return date;
    }
}