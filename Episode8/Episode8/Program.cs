using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading;

namespace Episode8
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            Load(people);

            for (int i = 0; i < 10; i++)
            {
                int sum = 0;
                try
                {
                    Enumerable.Range(1, 100000)
                        .AsParallel()
                        .Select(n => {
                            throw new Exception("Booom!");
                            sum += n;
                            return n;
                        })
                        .ToList();
                }
                catch (AggregateException ex)
                {
                    foreach (Exception exception in ex.InnerExceptions)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                
                Console.WriteLine(sum);
            }
            Console.ReadLine();

            /*foreach (Person person in namesStartingWithJ)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }*/
        }

        static void Load(List<Person> people)
        {
            var rand = new Random();
            rand.Next(5);
            for (int i = 0; i < 1000; i++)
            {
                string firstName = null;
                switch (rand.Next(5))
                {
                    case 0: firstName = "Bill"; break;
                    case 1: firstName = "Justin"; break;
                    case 2: firstName = "Ted"; break;
                    case 3: firstName = "Frank"; break;
                    case 4: firstName = "Bill"; break;
                    case 5: firstName = "Adam"; break;
                }

                string lastName = null;
                switch (rand.Next(5))
                {
                    case 0: lastName = "Etheredge"; break;
                    case 1: lastName = "Smith"; break;
                    case 2: lastName = "Johnson"; break;
                    case 3: lastName = "Doe"; break;
                    case 4: lastName = "Baker"; break;
                    case 5: lastName = "Williams"; break;
                }

                var person = new Person(i, firstName, lastName);
                people.Add(person);
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
