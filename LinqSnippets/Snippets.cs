namespace LinqSnippets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    public class Snippets
    {
        public static void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A4",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // 1. Select * of all cars
            var carList = from car in cars select car;
            foreach ( var car in carList )
            {
                Console.WriteLine(car);
            }

            // 2. Select Where car is Audio
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }            
        }
        public static void LinQNumbers()
        {
            // Number examples
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each number multiplied by 3
            // Take all numbers, except 9
            // Order numbers by ascending value

            var processedNumberList = numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }
        public static void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };
            // 1. First of all elements
            var first = textList.First();
            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));
            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "Z" or default
            var firstOrDefault = textList.FirstOrDefault(textList => textList.Contains("z"));
            // 5. Last element that contains "Z" or default
            var lastOrDefault = textList.LastOrDefault(textList => textList.Contains("z"));

            // 6.Single Values
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6};

            // Obtain {4,8}
            var myEventNumbers = evenNumbers.Except(otherEvenNumbers);
        }
        public static void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3",
            };
            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));
            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employes = new[]
                    {
                        new Employe
                        {
                            Id = 1,
                            Name = "Marc",
                            Email = "marc@gmail.com",
                            Salary = 1000,
                        },
                        new Employe
                        {
                            Id = 2,
                            Name = "Benavent",
                            Email = "benavent@gmail.com",
                            Salary = 2000,
                        },
                        new Employe
                        {
                            Id = 3,
                            Name = "Amaya",
                            Email = "amaya@gmail.com",
                            Salary = 3000,
                        },
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employes = new[]
                    {
                        new Employe
                        {
                            Id = 4,
                            Name = "Anna",
                            Email = "anna@gmail.com",
                            Salary = 1500,
                        },
                        new Employe
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@gmail.com",
                            Salary = 2040,
                        },
                        new Employe
                        {
                            Id = 6,
                            Name = "Sigaria",
                            Email = "sigaria@gmail.com",
                            Salary = 3540,
                        },
                    }
                },
            };

            // Obtain all Employes for all Enterprises
            var employeeList = enterprises.SelectMany(enterprises => enterprises.Employes);
            // Know if any list is empty
            bool hasEnterprises = enterprises.Any();
            bool hasEmployes = enterprises.Any(enterprises => enterprises.Employes.Any());

            // All enterprises at least has an employee with at least 1500€ of salary
            bool hasEmployeWithSalaryMoreThan1000 =
                enterprises.Any(enterprises => enterprises.Employes.Any(employe => employe.Salary >= 1500));
        }
        public static void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // Inner Join
            var commonResult = from element in firstList
                               join element2 in secondList
                               on element equals element2
                               select new { element, element2 };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    element2 => element2,
                    (element, element2) => new { element, element2 }
                );
            // Outer join - Left
            var leftOuterJoin = from element in firstList
                                join element2 in secondList
                                on element equals element2
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            // Outer joint - Left compressed lines
            var leftOuterJoint2 = from element in firstList
                                  from element2 in secondList
                                  .Where(s => s == element).DefaultIfEmpty()
                                  select new { Element = element, Element2 =  element2};
            

            // Outer joint - Right
            var rightOuterJoin = from element2 in secondList
                                 join element in firstList
                                on element2 equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element2 != temporalElement
                                select new { Element = element2 };
            // Union
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }
        public static void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10,11,12,
            };

            // Skip
            var skipTwoFirstElementValues = myList.Skip(2); //3,4,5,6,7,8,9,10,11,12
            var skipLastTwoElementValues = myList.SkipLast(2); //1,2,3,4,5,6,7,8,9,10

            var skipWhile = myList.SkipWhile(s => s < 4); // (4,5,6,7,8,9,10,11,12) | si <=4 (5,6,7,8,9,10,11,12)

            // Take
            var takeFirstTwoValues = myList.Take(2); // 1,2
            var takeLastTwoValues = myList.TakeLast(2); // 11,12
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);

            // TODO

            // Variables
            // Zip
            // Repeat
            // All
            // Aggregate
            // Disctinct
            // GroupBy
        }
    }
}