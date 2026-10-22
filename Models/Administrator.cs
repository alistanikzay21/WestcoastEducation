namespace WestcoastEducation.Models;

public class Administrator
{
    public required EducationManager EducationManagerInformation { get; set; }

    public string GetInformation()
    {
        return $"ADMINISTRATÖR\n{EducationManagerInformation}";
    }

    public override string ToString()
    {
        return GetInformation();
    }
}