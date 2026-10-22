namespace WestcoastEducation.Models;

public class Teacher
{
    public required Person PersonalInformation { get; set; }
    public required string KnowledgeArea { get; set; }
    public List<Course> ResponsibleCourses { get; set; } = new();

    public void AddCourse(Course course)
    {
        ResponsibleCourses.Add(course);
    } 

    public string GetInformation()
    {
        string courseInformation ="";

        if (ResponsibleCourses.Count == 0)
        {
            courseInformation = "Inga ansvariga kurser";
        }

        else
        {
            foreach (Course course in ResponsibleCourses)
            {
                courseInformation += $"\n{course.Titel}"; 
            }
        }

        return $"LÄRARE\n{PersonalInformation}\n" +
               $"Kunskapsområde: {KnowledgeArea}\n" +
               $"Ansvariga kurser: {courseInformation}";
    }

    public override string ToString()
    {
        return GetInformation();
    }

}