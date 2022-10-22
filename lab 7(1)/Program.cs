using System;

namespace Person
{
    public interface IPerson
    {
        string Name { get; }

        int Age { get; }
    }

    public interface IBirthable
    {
        string Birthdate { get; }
    }

    public interface IIdentifiable
    {
        string Id { get; }
    }

    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                ValidateNotNull(value, nameof(this.name));

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Invalid {nameof(this.age)}");
                }

                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                ValidateNotNull(value, nameof(this.id));

                this.id = value;
            }
        }

        public string Birthdate
        {
            get => this.birthdate;
            private set
            {
                ValidateNotNull(value, nameof(this.birthdate));

                this.birthdate = value;
            }
        }

        private static void ValidateNotNull(string value, string type)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Invalid {type}");
            }
        }
    }
}

namespace Person
{
    public class Startup  
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                string id = Console.ReadLine();
                string birthdate = Console.ReadLine();
                IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
                IBirthable birthable = new Citizen(name, age, id, birthdate);
                Console.WriteLine(identifiable.Id);
                Console.WriteLine(birthable.Birthdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}