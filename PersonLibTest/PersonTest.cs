using System;
using System.Collections.Generic;
using Xunit;
using Zorrolord.Model.PersonLib;

namespace PersonLibTest
{
    public class PersonTest
    {
        static string firstName = "FirstNameTest";
        static string lastName = "LastNameTest";

        [Fact]
        public void CreateConstructor_Passing()
        {
            Person p = new();

            Assert.NotNull(p);
            //Assert.Equal($"", p.ToString());
        }

        [Fact]
        public void CreateConstructorWithArguments_Passing()
        {
            Person p = new(firstName, lastName);

            Assert.Equal(firstName, p.FirstName);
            Assert.Equal(lastName, p.LastName);

            Assert.Equal($"{firstName} {lastName}", p.ToString());
        }

        [Fact]
        public void CreateConstructorWithProperties_Passing()
        {
            Person p = new()
            {
                FirstName = firstName,
                LastName = lastName
            };

            Assert.Equal(firstName, p.FirstName);
            Assert.Equal(lastName, p.LastName);

            Assert.Equal($"{firstName} {lastName}", p.ToString());
        }

        public static IEnumerable<object[]> GetData_Failing()
        {
            yield return new object[] { null, lastName, $"{nameof(Person)}:{nameof(Person.FirstName)}" };
            yield return new object[] { firstName, null, $"{nameof(Person)}:{nameof(Person.LastName)}" };
            yield return new object[] { string.Empty, lastName, $"{nameof(Person)}:{nameof(Person.FirstName)}" };
            yield return new object[] { firstName, string.Empty, $"{nameof(Person)}:{nameof(Person.LastName)}" };
            yield return new object[] { " ", lastName, $"{nameof(Person)}:{nameof(Person.FirstName)}" };
            yield return new object[] { firstName, " ", $"{nameof(Person)}:{nameof(Person.LastName)}" };
        }

        [Theory]
        [MemberData(nameof(GetData_Failing))]
        public void CreateConstructorWithArguments_Failing(string firstName, string lastName, string message)
        {
            Person p;

            Exception ex = Assert.Throws<Exception>(() => p = new(firstName, lastName));

            Assert.Equal(message, ex.Message);

        }
    }
}
