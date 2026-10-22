namespace WestcoastEducation.Models;

public class Student
{
    public required Person PersonalInformation { get; set; }

    public string GetInformation()
    {
        return $"STUDENT\n{PersonalInformation}";
    }

    public override string ToString()
    {
        return GetInformation();
    }

}