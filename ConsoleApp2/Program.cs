using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonRelationApp
{
    // Person class definition
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColour { get; set; }
        public int Age { get; set; }
        public bool IsWorking { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public void ChangeFavoriteColour(string newColour = "White")
        {
            FavoriteColour = newColour;
        }

        public int AgeInTenYears() => Age + 10;

        public override string ToString() =>
            $"PersonId: {PersonId}\n" +
            $"FirstName: {FirstName}\n" +
            $"LastName: {LastName}\n" +
            $"FavoriteColour: {FavoriteColour}\n" +
            $"Age: {Age}\n" +
            $"IsWorking: {IsWorking}";
    }

    // Relation class definition
    public class Relation
    {
        public string RelationshipType { get; set; }

        public void Show(Person person1, Person person2)
        {
            Console.WriteLine($"Relationship between {person1.FirstName} and {person2.FirstName}: {RelationshipType}");
        }
    }

    class Program
    {
        static void Main()
        {
            var people = new List<Person>
            {
                new Person { PersonId = 1, FirstName = "Ian", LastName = "Brooks", FavoriteColour = "Red", Age = 30, IsWorking = true },
                new Person { PersonId = 2, FirstName = "Gina", LastName = "James", FavoriteColour = "Green", Age = 18, IsWorking = false },
                new Person { PersonId = 3, FirstName = "Mike", LastName = "Briscoe", FavoriteColour = "Blue", Age = 45, IsWorking = true },
                new Person { PersonId = 4, FirstName = "Mary", LastName = "Beals", FavoriteColour = "Yellow", Age = 28, IsWorking = true }
            };

            // Display specific person information
            DisplayPersonInfo(people[1]); // Gina

            // Display all of Mike's information
            people[2].DisplayInfo();

            // Change Ian's favorite colour and display
            people[0].ChangeFavoriteColour();
            Console.WriteLine($"{people[0].FirstName}'s new favorite colour: {people[0].FavoriteColour}");

            // Display Mary's age in 10 years
            Console.WriteLine($"{people[3].FirstName}'s age in 10 years: {people[3].AgeInTenYears()}");

            // Show relationships
            var relation1 = new Relation { RelationshipType = "Sisterhood" };
            relation1.Show(people[1], people[3]); // Gina and Mary

            var relation2 = new Relation { RelationshipType = "Brotherhood" };
            relation2.Show(people[0], people[2]); // Ian and Mike

            // Calculate and display average age
            DisplayAverageAge(people);

            // Find and display youngest and oldest person
            DisplayYoungestAndOldest(people);

            // Display persons with names starting with 'M'
            DisplayPersonsByNameStart(people, 'M');

            // Display person who likes the colour blue
            DisplayPersonByFavoriteColour(people, "Blue");
        }

        static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine($"{person.PersonId}: {person.FirstName} {person.LastName}'s favorite colour is {person.FavoriteColour}");
        }

        static void DisplayAverageAge(List<Person> people)
        {
            double averageAge = people.Average(p => p.Age);
            Console.WriteLine($"Average age is: {averageAge:F2}");
        }

        static void DisplayYoungestAndOldest(List<Person> people)
        {
            var youngest = people.OrderBy(p => p.Age).First();
            var oldest = people.OrderByDescending(p => p.Age).First();

            Console.WriteLine($"The youngest person is: {youngest.FirstName}");
            Console.WriteLine($"The oldest person is: {oldest.FirstName}");
        }

        static void DisplayPersonsByNameStart(List<Person> people, char startLetter)
        {
            var filtered = people.Where(p => p.FirstName.StartsWith(startLetter));

            Console.WriteLine($"Persons whose names start with '{startLetter}':");
            foreach (var person in filtered)
            {
                person.DisplayInfo();
            }
        }

        static void DisplayPersonByFavoriteColour(List<Person> people, string colour)
        {
            var person = people.FirstOrDefault(p => p.FavoriteColour == colour);

            if (person != null)
            {
                Console.WriteLine($"Person who likes {colour}:\n{person}");
            }
            else
            {
                Console.WriteLine($"No person found with favorite colour {colour}.");
            }
        }
    }
}
