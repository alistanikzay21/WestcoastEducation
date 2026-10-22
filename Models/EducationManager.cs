namespace WestcoastEducation.Models;

public class EducationManager
{
    public required Teacher TeacherInformation { get; set; }
    public required DateOnly EmploymentDate { get; set; }
}