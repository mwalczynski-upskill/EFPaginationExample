using System;
using System.Collections.Generic;
using EFPaginationExample.Interfaces;
using EFPaginationExample.Models;
using EFPaginationExample.Repositories;

namespace EFPaginationExample
{
    class Program
    {
        public static IRepository<Person> Repository = new Repository<Person>();

        static void Main(string[] args)
        {
            SeedDatabase();

            var page = 2;
            var pageSize = 5;
            Func<Person, bool> filter = x => x.Age > 12;
            Func<Person, object> order = x => -x.Age;

            var pagedData = Repository.SelectPagedData(page, pageSize, filter, order);

            foreach (var person in pagedData)
            {
                Console.WriteLine($@"{person.FirstName}, {person.SecondName}, {person.Age}");
            }

            Console.ReadKey();
        }
        public static void SeedDatabase()
        {
            if (!Repository.Any())
            {
                var personsToAdd = new List<Person>()
                {
                    new Person("A", "A", 1),
                    new Person("B", "B", 2),
                    new Person("C", "C", 3),
                    new Person("D", "D", 4),
                    new Person("E", "E", 5),
                    new Person("F", "F", 6),
                    new Person("G", "G", 7),
                    new Person("H", "H", 8),
                    new Person("I", "I", 9),
                    new Person("J", "J", 10),
                    new Person("K", "K", 11),
                    new Person("L", "L", 12),
                    new Person("M", "M", 13),
                    new Person("N", "N", 14),
                    new Person("O", "O", 15),
                    new Person("Q", "Q", 16),
                    new Person("P", "P", 17),
                    new Person("R", "R", 18),
                    new Person("S", "S", 19),
                    new Person("T", "T", 21),
                    new Person("U", "U", 22),
                    new Person("W", "W", 23),
                    new Person("X", "X", 24),
                    new Person("Y", "Y", 25),
                    new Person("Z", "Z", 26),
                };

                foreach (var person in personsToAdd)
                {
                    Repository.Add(person);
                }
            }
        }
    }
}
