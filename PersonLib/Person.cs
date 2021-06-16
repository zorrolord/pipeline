using System;

namespace Zorrolord.Model.PersonLib
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public Person() { }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{nameof(Person)}:{nameof(FirstName)}");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{nameof(Person)}:{nameof(LastName)}");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
