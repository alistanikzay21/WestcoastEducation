namespace WestcoastEducation.Models;

public class EducationManager
{
    public required Teacher TeacherInformation { get; set; }
    public required DateOnly EmploymentDate { get; set; }

    public string GetInformation()
    {
        return $"UTBILDNINGSCHEF\n{TeacherInformation}\n" +
               $"Anställningsdatum: {EmploymentDate}";
    }
    public override string ToString()
    {
        return GetInformation();
    }
}