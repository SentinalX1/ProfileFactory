using System;
using System.Collections.Generic;

abstract class Profile
{
    public string Country { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public DateTime DateOfBirth { get; set; }

    public abstract void InputSpecificInfo();
    public abstract void DisplayProfileInfo();
}

class ClientProfile : Profile
{
    public string CompanyName { get; set; }
    public string Occupation { get; set; }

    public override void InputSpecificInfo()
    {
        Console.Write("Enter Company Name: ");
        CompanyName = Console.ReadLine();

        Console.Write("Enter Occupation: ");
        Occupation = Console.ReadLine();
    }

    public override void DisplayProfileInfo()
    {
        Console.WriteLine("Profile Type: Client");
        Console.WriteLine($"Country: {Country}");
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Postal Code: {PostalCode}");
        Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Company Name: {CompanyName}");
        Console.WriteLine($"Occupation: {Occupation}");
    }
}

class FreelancerProfile : Profile
{
    public List<string> Skills { get; set; }
    public int ExperienceYears { get; set; }

    public FreelancerProfile()
    {
        Skills = new List<string>();
    }

    public override void InputSpecificInfo()
    {
        Console.Write("Enter years of experience: ");
        ExperienceYears = int.Parse(Console.ReadLine());

        Console.Write("Enter number of skills: ");
        int numSkills = int.Parse(Console.ReadLine());
        for (int i = 0; i < numSkills; i++)
        {
            Console.Write($"Enter Skill {i + 1}: ");
            Skills.Add(Console.ReadLine());
        }
    }

    public override void DisplayProfileInfo()
    {
        Console.WriteLine("Profile Type: Freelancer");
        Console.WriteLine($"Country: {Country}");
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Postal Code: {PostalCode}");
        Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Years of Experience: {ExperienceYears}");
        Console.WriteLine("Skills: " + string.Join(", ", Skills));
    }
}

class ProfileFactory
{
    public static Profile CreateProfile(string profileType)
    {
        if (profileType.Equals("client", StringComparison.OrdinalIgnoreCase))
        {
            return new ClientProfile();
        }
        else if (profileType.Equals("freelancer", StringComparison.OrdinalIgnoreCase))
        {
            return new FreelancerProfile();
        }
        else
        {
            throw new ArgumentException("Invalid profile type.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Profile System");
        Console.Write("Enter profile type (client/freelancer): ");
        string profileType = Console.ReadLine();

        try
        {
            Profile profile = ProfileFactory.CreateProfile(profileType);

            Console.Write("Enter Country: ");
            profile.Country = Console.ReadLine();

            Console.Write("Enter Region: ");
            profile.Region = Console.ReadLine();

            Console.Write("Enter Postal Code: ");
            profile.PostalCode = Console.ReadLine();

            Console.Write("Enter Date of Birth (MM/DD/YYYY): ");
            profile.DateOfBirth = DateTime.Parse(Console.ReadLine());

            profile.InputSpecificInfo();

            Console.WriteLine("\nProfile Information:");
            profile.DisplayProfileInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
