using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static ExerciseSolutions.Chapter07.Exercises;

namespace ExerciseTests.Chapter07;

[TestClass]
public class Tests
{
    private record Person(string FirstName, string LastName);

    [TestMethod]
    public void Compose_Success()
    {
        Person p = new("Barry", "Wallis");
        Func<Person, string> compose = Compose<Person, string, string>(AppendDomain, AbbreviateName);
        string actual = compose(p);
        Assert.AreEqual("bawa@manning.com", actual);

        static string AbbreviateName(Person p) => Abbreviate(p.FirstName) + Abbreviate(p.LastName);

        static string AppendDomain(string localPart) => $"{localPart}@manning.com";

        static string Abbreviate(string s) => s[..Math.Min(2, s.Length)].ToLower(System.Globalization.CultureInfo.InvariantCulture);
    }
}
