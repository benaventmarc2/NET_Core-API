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
        }
        // TODO

        // Paging with skip & take
        public static IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber -1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }
        // Variables
        public static void LinQVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;
            Console.WriteLine("Average: {0}", numbers.Average());
            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Query: Number: {0} Square: {1}", number, MathF.Pow(number,2));
            }
        }
        // Zip
        public static void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };
            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);
        }
        // Repeat & Range
        public static void RepeatRangeLinQ()
        {
            // Generate a collection values from 1 - 1000 Range
            var first1000 = Enumerable.Range(1, 1000);
            // Repeat a value N times
            var fiveXs = Enumerable.Repeat("X", 5); // {"X" "X" "X" "X" "X"}
        }
        public static void StudentsLinQ()
        {
            var classRooom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Marc",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Anna",
                    Grade = 20,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Jhon",
                    Grade = 70,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Karol",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pep",
                    Grade = 35,
                    Certified = true,
                },
            };

            var certifiedStudents = from student in classRooom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from Student in classRooom
                                       where !Student.Certified
                                       select Student;

            var aprovedStudent = from student in classRooom
                                 where student.Grade >= 50 && student.Certified
                                 select student;
        }

        // All
        public static void AllLinq()
        {
            var numbers = new List<int>() { 1,2,3,4,5};
            bool allAreSmallerThan10 = numbers.All(x => x < 10);
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2);

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(numbers => numbers >= 0);
        }

        // Aggregate
        public static void AggregateQuerys()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = { "hello", "my", "name", "is", "Marc" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
        }

        // Disctinct
        public static void DistinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        // GroupBy
        public static void GroupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);
            // We will have two groups:
            // 1. The group that doesnt fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)
            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 |_| 2,4,6,8
                }
            }

            var classRooom = new[]
           {
                new Student
                {
                    Id = 1,
                    Name = "Marc",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Anna",
                    Grade = 20,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Jhon",
                    Grade = 70,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Karol",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pep",
                    Grade = 35,
                    Certified = true,
                },
            };

            var certifiedQuery = classRooom.GroupBy(student => student.Certified && student.Grade >= 50);
            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("------{0}------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
        public static void RelationsLinQ()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Tittle = "My first post",
                    Content = "My first content asdfasdfasdf",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Tittle = "My first comment",
                            Content = "My coment asdfasdvasd",
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Tittle = "My second comment",
                            Content = "My coment 2 asdfasdvasd",
                        }
                    }

                },
                new Post()
                {
                    Id = 2,
                    Tittle = "My second post",
                    Content = "My second content asdfasdfasdf",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Tittle = "My first comment",
                            Content = "My coment asdfasdvasd",
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Tittle = "My second comment",
                            Content = "My coment 2 asdfasdvasd",
                        }
                    }

                }
            };

            var commentsContent = posts.SelectMany(
                post => post.Comments,
                (post, comment) => new { PostId = post.Id, CommentContent = comment.Content} );
        }

    }
}