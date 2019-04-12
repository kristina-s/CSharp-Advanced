using System.Collections.Generic;
using LinqExercise.Services;
using LinqExercise.Models;
using System.Linq;
using System;

namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = PersonService.GetAllPeople();

            var dogs = DogService.GetAllDogs();

            #region Exercises

            //==============================
            // TODO LINQ expressions :)
            // Your turn guys...
            //==============================

            //PART 1
            // 1. Take person Cristofer and add Jack, Ellie, Hank and Tilly as his dogs.
            // 2. Take person Freddy and add Oscar, Toby, Chanel, Bo and Scout as his dogs.
            // 3. Add Trixie, Archie and Max as dogs from Erin.
            // 4. Give Abby and Shadow to Amelia.
            // 5. Take person Larry and Zoe, Ollie as his dogs.
            // 6. Add all retrievers to Erika.
            // 7. Erin has plus Chet and Ava 
            // 8. and now give Diesel to August thah previously has just Rigby

            //PART 2 - LINQ
            // 1. Find and print all persons firstnames starting with 'R', ordered by age - DESCENDING ORDER.
            // 2. Find and print all brown dogs names and ages older than 3 years, ordered by age - ASCENDING ORDER.
            // 3. Find and print all persons with more than 2 dogs, ordered by name - DESCENDING ORDER.
            // 4. Find and print all persons names, last names and job positions that have just one race type dogs.
            // 5. Find and print all Freddy`s dogs names older than 1 year, grouped by dogs race.
            // 6. Find and print last 10 persons grouped by their age.
            // 7. Find and print all dogs names from Cristofer, Freddy, Erin and Amelia, grouped by color and ordered by name - ASCENDING ORDER.
            // 8. Find and persons that have at least one same dogs race and order them by name length ASCENDING, then by age DESCENDING.
            // 9. Find the last dog of Amelia and print all dogs form other persons older than Amelia, ordered by dogs age DESCENDING.
            // 10. Find all developers older than 20 with more than 1 dog that contains letter 'e' in the name and print their names and job positions.

            #endregion

            #region PART 1
            Person cristofer = people
                .FirstOrDefault(x => x.FirstName == "Cristofer");
            if(cristofer != null)
            {
                cristofer.Dogs = dogs
                    .Where(x => x.Name == "Jack" || x.Name == "Ellie" || x.Name == "Hank" || x.Name == "Tilly")
                    .ToList();
            }
            Person freddy = people
                .FirstOrDefault(x => x.FirstName == "Freddy");
            if (freddy != null)
            {
                freddy.Dogs = dogs
                    .Where(x => x.Name == "Oscar" || x.Name == "Toby" || x.Name == "Chanel" || x.Name == "Bo" || x.Name == "Scout")
                    .ToList();
            }

            Person erin = people
                .FirstOrDefault(x => x.FirstName == "Erin");
            if (erin != null)
            {
                erin.Dogs = dogs
                    .Where(x => x.Name == "Trixie" || x.Name == "Archie" || x.Name == "Max")
                    .ToList();
            }

            Person amelia = people
                .FirstOrDefault(x => x.FirstName == "Amelia");
            if (amelia != null)
            {
                amelia.Dogs = dogs
                    .Where(x => x.Name == "Abby" || x.Name == "Shadow")
                    .ToList();
            }

            Person larry = people
                .FirstOrDefault(x => x.FirstName == "Larry");
            if (larry != null)
            {
                larry.Dogs = dogs
                    .Where(x => x.Name == "Zoe" || x.Name == "Ollie")
                    .ToList();
            }

            Person erika = people
                .FirstOrDefault(x => x.FirstName == "Erika");
            if (erika != null)
            {
                erika.Dogs = dogs
                    .Where(x => x.Race == Race.Retriever)
                    .ToList();
            }

            if (erin != null)
            {
                erin.Dogs.Add(dogs.Where(x => x.Name == "Chet").FirstOrDefault());
                erin.Dogs.Add(dogs.Where(x => x.Name == "Ava").FirstOrDefault());
                //erin.PrintAllDogs();
            }

            Person august = people
                .FirstOrDefault(x => x.FirstName == "August");
            if (august != null)
            {
                august.Dogs = dogs
                    .Where(x => x.Name == "Diesel" || x.Name == "Rigby")
                    .ToList();
                //august.PrintAllDogs();
            }
            #endregion

            #region PART 2

            // 1. Find and print all persons firstnames starting with 'R', ordered by age - DESCENDING ORDER.
            List<Person> startWithRDesc = people
                .Where(x => x.FirstName.StartsWith("S"))
                .OrderByDescending(x => x.Age)
                .ToList();

            // 2. Find and print all brown dogs names and ages older than 3 years, ordered by age - ASCENDING ORDER.
            List<Dog> brownDogs = dogs
                .Where(x => x.Color == Color.Brown && x.Age > 3)
                .OrderBy(x => x.Age)
                .ToList();
            //PrintListDogs(brownDogs);

            // 3. Find and print all persons with more than 2 dogs, ordered by name - DESCENDING ORDER.
            List<Person> moreThan2Dogs = people
                .Where(x => x.Dogs != null && x.Dogs.Count > 2)
                .OrderByDescending(x => x.FirstName)
                .ToList();
            //PrintListPerson(moreThan2Dogs);

            // 4. Find and print all persons names, last names and job positions that have just one race type dogs.
            List<Person> oneTypeDogs = people
                .Where(x => x.Dogs != null && x.Dogs.Select(y => y.Race).Distinct().Count() == 1)
                .ToList();
            //PrintListPerson(oneTypeDogs);

            // 5. Find and print all Freddy`s dogs names older than 1 year, grouped by dogs race.

            var freddiesDogs = freddy.Dogs
                .Where(x => x.Age > 1)
                .GroupBy(x => x.Race)
                .ToList();
            //foreach (var group in freddiesDogs)
            //{
            //    Console.WriteLine($"Dogs from race: {group.Key}");
            //    foreach (var dog in group)
            //    {
            //        Console.WriteLine($"{dog.Name}");
            //    }
            //}

            // 6. Find and print last 10 persons grouped by their age.
            var ageGroup = people
                .GroupBy(x => x.Age)
                .Reverse()
                .Take(10)
                .ToList();
            //foreach (var group in ageGroup)
            //{
            //    Console.WriteLine($"Age: {group.Key}");
            //    foreach (var person in group)
            //    {
            //        Console.WriteLine($"{person.FirstName} {person.LastName}");
            //    }
            //}

            // 7. Find and print all dogs names from Cristofer, Freddy, Erin and Amelia, grouped by color and ordered by name - ASCENDING ORDER.
            var dogNames = people
                .Where(x => x.FirstName == "Cristofer" || x.FirstName == "Freddy" || x.FirstName == "Erin" || x.FirstName == "Amelia")
                .SelectMany(x => x.Dogs)
                .OrderBy(x => x.Name)
                .GroupBy(x => x.Color)
                .ToList();
            //foreach (var group in dogNames)
            //{
            //    Console.WriteLine($"Dogs with color: {group.Key}");
            //    foreach (var dog in group)
            //    {
            //        Console.WriteLine($"{dog.Name}");
            //    }
            //}

            // 8. Find and persons that have same dogs races and order them by name length ASCENDING, then by age DESCENDING.
            var sameRaces = people
                .Where(x => x.Dogs != null)
                .SelectMany(x => x.Dogs)
                .GroupBy(y => y.Race)
                .Select(x => x.Key)
                .ToList();
            
            //foreach (var item in sameRaces)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            var peopleWithSameRace = people
                .Where(x => x.Dogs != null && x.Dogs.Select(y => y.Race).Intersect(sameRaces).ToList().Count() != 0)
                .ToList();

            //PrintListPerson(peopleWithSameRace);
            

            // 9. Find the last dog of Amelia and print all dogs form other persons older than Amelia, ordered by dogs age DESCENDING.
            Dog lastAmelia = amelia.Dogs
                .LastOrDefault();
            List<Dog> otherOlder = dogs
                .Where(x => x.Age > lastAmelia.Age)
                .OrderByDescending(x => x.Age)
                .ToList();
            //Console.WriteLine($"{lastAmelia.Age}");
            //PrintListDogs(otherOlder);

            // 10. Find all developers older than 20 with more than 1 dog that contains letter 'e' in the name and print their names and job positions.
            var developers = people
                .Where(x => x.Occupation == Job.Developer && x.Age > 20)
                .Where(x => x.Dogs != null && x.Dogs.Count() > 1)
                .Where(x => x.Dogs.Any(y => y.Name.Contains("e")))
                //.Where(x => x.Dogs.Where(z => z.Name.Contains("e")))
                //or
                //.Select(x => x.Dogs.Where(y => y.Name.Contains("e")))
                .ToList();
                
            PrintListPerson(developers);
            #endregion

            Console.ReadLine();
        }
        public static void PrintListPerson(List<Person> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.Occupation}");
            }
        }
        public static void PrintListDogs(List<Dog> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} {item.Age} {item.Race} ");
            }
        }
    }
}