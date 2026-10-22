namespace WestcoastEducation.Models;

public class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PersonalNumber { get; set; }
    public required string Adress { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }

    public override string ToString()
    {
        return $"Namn: {FirstName} {LastName}\n" +
               $"Telefonnummer: {PhoneNumber}\n" +
               $"Personnummer: {PersonalNumber}\n" + 
               $"Adress: {Adress}\n" +
               $"Postnummer: {PostalCode}\n" +
               $"Ort: {City}";
    }

}