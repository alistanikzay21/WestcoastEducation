using WestcoastEducation.Enums;

namespace WestcoastEducation.Models;

public class Course
{
    public required string CourseNumber { get; set; }
    public required string Titel { get; set; }
    public required string Length { get; set; }
    public required LengthUnitEnum LengthUnit { get; set; }
    public required CourseTypeEnum CourseType { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }

    public override string ToString()
    {
        return $"Kursnummer: {CourseNumber}\n" +
               $"Kursnamn: {Titel}\n" +
               $"Kurslängd: {Length} {LengthUnit}\n" +
               $"Typ: {CourseType}\n" +
               $"Startdatum: {StartDate}\n" +
               $"Slutdatum: {EndDate}";
    } 
}