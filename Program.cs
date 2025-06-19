using System;

namespace EqualityDemoV1
{
    // Classic reference-type with explicit equality logic
    public class Employee : IEquatable<Employee>
    {
        private int    _id;
        private string _firstName = string.Empty;
        private string _lastName  = string.Empty;

        public int Id
        {
            get => _id;
            set => _id = value > 0
                ? value
                : throw new ArgumentException("Employee ID must be positive.");
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("First name cannot be empty.")
                : value.Trim();
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Last name cannot be empty.")
                : value.Trim();
        }

        public Employee(int id, string firstName, string lastName)
        {
            Id        = id;
            FirstName = firstName;
            LastName  = lastName;
        }

        public override string ToString() =>
            $"Employee(ID: {Id}, Full Name: {FirstName} {LastName})";

        // Equality operators delegate to Equals
        public static bool operator ==(Employee a, Employee b) =>
            a is null ? b is null : a.Equals(b);

        public static bool operator !=(Employee a, Employee b) => !(a == b);

        public bool Equals(Employee? other) => other is not null && Id == other.Id;

        public override bool Equals(object? obj) => obj is Employee e && Equals(e);

        public override int GetHashCode() => Id.GetHashCode();
    }

    class Program
    {
        static void Main()
        {
            var e1 = new Employee(101, "Sarah",  "Wilson");
            var e2 = new Employee(101, "Michael","Brown");
            var e3 = new Employee(102, "Emma",   "Davis");

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);
            Console.WriteLine();

            Console.WriteLine($"e1 == e2 : {e1 == e2}");
            Console.WriteLine($"e1 != e3 : {e1 != e3}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
