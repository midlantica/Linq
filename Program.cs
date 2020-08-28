using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE DONUT DRAWER!");

            //WHAT ARE OUR FAVORITE FLAVORS???
            List<string> FavFlavors = new List<string>()
            {
                "Plain Glazed",
                "Chocolate",
                "Cinnamon",
                "Old Fashioned"
            };

            // FavFlavors.ForEach(flavor => Console.WriteLine($"{flavor} is the best donut flavor of all time"));

            // FavFlavors.Add("Gravel");
            // Console.WriteLine("-----WITH A NEW FLAVOR-----");
            // FavFlavors.ForEach(flavor => Console.WriteLine($"{flavor} is the best donut flavor of all time"));

            // FavFlavors.Remove("Gravel");
            // Console.WriteLine("-----NO MORE GRAVEL-----");

            // FavFlavors.ForEach(flavor => Console.WriteLine($"{flavor} is the best donut flavor of all time"));
            //HOW MUCH DO THEY COST????????????

            // Dictionary<string, double> DonutDictionary = new Dictionary<string, double>()
            // { { "Old Fashioned", 20.30 }, { "Plain Glazed", 1000.00 }, { "Chocolate", 55.45 }
            // };
            // Console.WriteLine("BEFORE ADDING A DONUT!");
            // foreach (KeyValuePair<string, double> donut in DonutDictionary)
            // {
            //     Console.WriteLine($"A {donut.Key} costs ${donut.Value}");
            // }

            // DonutDictionary.Add("Maple Bacon", 2.00);
            // Console.WriteLine("AFTER ADDING A DONUT!!!!!!!!");
            // foreach (KeyValuePair<string, double> donut in DonutDictionary)
            // {
            //     Console.WriteLine($"A {donut.Key} costs ${donut.Value}");
            // }
            // DonutDictionary.Remove("Maple Bacon");
            //    Console.WriteLine("AFTER removing A DONUT!!!!!!!!");
            // foreach (KeyValuePair<string, double> donut in DonutDictionary)
            // {
            //     Console.WriteLine($"A {donut.Key} costs ${donut.Value}");
            // }

            //LINQ TIME!

            List<double> DonutPrices = new List<double>()
            {
                1.00,
                2.00,
                300.03,
                .89
            };

            double mostExpensive = DonutPrices.Max();
            double leastExpensive = DonutPrices.Min();
            double cumulativeCost = DonutPrices.Sum();
            // Console.WriteLine($"The most expensive donut costs {mostExpensive}");
            // Console.WriteLine($"The least expensive donut costs {leastExpensive}");
            // Console.WriteLine($"The combined donut costs is equal to {cumulativeCost}");

            //List of students
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Amanda",
                    LastName = "King",
                    Age = 1581,
                    FavoriteBreakoutRoom = "Stan the Vegetable Man",
                    IsBrendasAngel = true
                },
                new Student()
                {
                    FirstName = "Zach",
                    LastName = "McWhirter",
                    Age = 312,
                    FavoriteBreakoutRoom = "World's Largest Mailbox",
                    IsBrendasAngel = true'
                },
                new Student()
                {
                    FirstName = "Kelley",
                    LastName = "Crittenden",
                    Age = 602,
                    FavoriteBreakoutRoom = "Whittlin",
                    IsBrendasAngel = true
                },
                new Student()
                {
                    FirstName = "Rob",
                    LastName = "Mixon",
                    Age = 2,
                    FavoriteBreakoutRoom = "Hardee's Parking Lot",
                    IsBrendasAngel = true
                },
                new Student()
                {
                    FirstName = "John",
                    LastName = "Hester",
                    Age = 153,
                    FavoriteBreakoutRoom = "Whittlin",
                    IsBrendasAngel = false
                },
                new Student()
                {
                    FirstName = "Drew",
                    LastName = "Harper",
                    Age = 201,
                    FavoriteBreakoutRoom = "The Lobster Pot",
                    IsBrendasAngel = false
                },
                new Student()
                {
                    FirstName = "Andy",
                    LastName = "Collins",
                    Age = 3,
                    FavoriteBreakoutRoom = "Whittlin",
                    IsBrendasAngel = false
                }

            };

            //CAN WE SEE JUST THEIR LAST NAMES???????
            // students.ForEach(student => Console.WriteLine($"{student.LastName}"));

            //...OKAY COOL BUT CAN WE HAVE A LIST OF JUST... LAST....  NAMES???????????
            // List<string> lastNames = students.Select(student =>
            // {
            //     return student.LastName;
            // }).ToList();
            // lastNames.ForEach(name => Console.WriteLine($"{name}"));

            //WHO IN THIS CLASS IS UNDER 1000 YEARS OLD????????

            List<Student> youngestStudents = students.Where(student => student.Age < 1000).ToList();

            // youngestStudents.ForEach(student => Console.WriteLine($"{student.FirstName} is {student.Age} years old, and VERY youthful!!!!!!"));

            //WHO is AN ANGEL?????????????????

            //I GOTTA SEE THESE STUDENTS IN ALPHABETICAL ORDER ACCORDING TO THEIR LAST NAMES !!!!!!!!!!!!!!!!!!!!!!!!
            List<Student> AlphabeticalOrder = students.OrderBy(student => student.LastName).ToList();
            // AlphabeticalOrder.ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));

            // Console.WriteLine("");

            //JUST KIDDING THE OTHER WAY AROUND!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            List<Student> ReverseAlphabetical = students.OrderByDescending(student => student.LastName).ToList();
            // ReverseAlphabetical.ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));

            //HOW MANY STUDENTS HAVE THE SAME FAV BREAKOUT ROOM NAMES?????????????????????????

            List<BreakoutRoomReport> breakoutRoomReports = (from student in students group student by student.FavoriteBreakoutRoom into breakoutRoomGroup select new BreakoutRoomReport
                {
                    BreakoutRoomName = breakoutRoomGroup.Key,
                        StudentCount = breakoutRoomGroup.Count()
                }

            ).ToList();

            Console.WriteLine("BREAKOUT ROOM REPORT!!!!!!!!!!!!");
            breakoutRoomReports.ForEach(report => Console.WriteLine($"{report.BreakoutRoomName}: {report.StudentCount}"));

        }
        public class BreakoutRoomReport
        {
            public string BreakoutRoomName { get; set; }
            public int StudentCount { get; set; }
        }
    }
}
