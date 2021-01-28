using System;

namespace DemoNullCheck
{
    public class Person
    {
        public string Name { get; set; }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# Demo CS6 with Person");
            RunTestForCS6(new Person() { Name = "Robert"});
            Console.WriteLine("--------------------------------------------------\n");
            
            Console.WriteLine("# Demo CS6 with Null Person");
            RunTestForCS6(null);
            Console.WriteLine("--------------------------------------------------\n");
            
            
            Console.WriteLine("# Demo CS7 with Person");
            RunTestForCS7(new Person() { Name = "Robert"});
            Console.WriteLine("--------------------------------------------------\n");
            
            Console.WriteLine("# Demo CS7 with Null Person");
            RunTestForCS7(null);
            Console.WriteLine("--------------------------------------------------\n");
            
            
            Console.WriteLine("# Demo CS8 with Person");
            RunTestForCS8(new Person() { Name = "Robert"});
            Console.WriteLine("--------------------------------------------------\n");
            
            Console.WriteLine("# Demo CS8 with Null Person");
            RunTestForCS8(null);
            Console.WriteLine("--------------------------------------------------\n");
            
            
            Console.WriteLine("# Demo CS9 with Person");
            RunTestForCS9(new Person() { Name = "Robert"});
            Console.WriteLine("--------------------------------------------------\n");
            
            Console.WriteLine("# Demo CS9 with Null Person");
            RunTestForCS9(null);
            Console.WriteLine("--------------------------------------------------\n");
        }

        private static void RunTestForCS6(Person person)
        {
            if (person == null) // Be careful with overloaded operators
            {
                Console.WriteLine("[person == null] Person: Null");
            }

            if (person != null)
            {
                Console.WriteLine($"[person != null] Person: {person}");
            }

            Console.WriteLine($"Person Name: {person?.Name}");

            // ?? and ??= operators: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
            Person person2 = person ?? new Person() { Name = "Martin" };

            Console.WriteLine($"Person_2: {person2}");
            Console.WriteLine($"Person_2 Name: {person2?.Name}");
        }
        
        private static void RunTestForCS7(Person person)
        {
            if (person == null)
            {
                Console.WriteLine("[person == null] Person: Null");
            }

            if (person != null)
            {
                Console.WriteLine($"[person != null] Person: {person}");
            }
            
            // Pattern matching with is: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/is
            if (person is null)
            {
                Console.WriteLine($"[person is null] Person: {person}");
            }
            
            if (!(person is null))
            {
                Console.WriteLine($"[!(person is null)] Person: {person}");
            }

            if (person is object) // Not readable
            {
                Console.WriteLine($"[person is object] Person: {person}");
            }

            // Discards (_ = object): https://docs.microsoft.com/en-us/dotnet/csharp/discards
            // These are the same
            // _ = person ?? throw new ArgumentNullException(nameof(person));
            // if (person is null)
            // {
            //     throw new ArgumentNullException(nameof(person));
            // }
        }
        
        private static void RunTestForCS8(Person person)
        {
            if (person is {}) // same as: (person is object) | // Not readable
            {
                Console.WriteLine("[person is {}] Person: " + person);
            }

            // ?? and ??= operators: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
            person ??= new Person() {Name = "Martin"};
            Console.WriteLine($"$[person ??=] Person Name: {person?.Name}");
        }
        
        private static void RunTestForCS9(Person person)
        {
            if (person is null)
            {
                Console.WriteLine($"[person is null] Person: {person}");
            }
            
            if (person is not null)
            {
                Console.WriteLine($"[person is not null] Person: {person}");
            }
        }
    }
}