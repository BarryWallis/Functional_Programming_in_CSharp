using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExerciseSolutions.Chapter05;

using LaYumba.Functional;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static ExerciseSolutions.Chapter05.Exercises;
using static LaYumba.Functional.F;

namespace ExerciseTests.Chapter05;
[TestClass]
public class Tests
{
    [TestMethod]
    public void Parse_Some_Success()
    {
        Option<DayOfWeek> dayOfWeek = Exercises.Parse<DayOfWeek>("Friday");
        Assert.AreEqual(Some(DayOfWeek.Friday), dayOfWeek);
    }

    [TestMethod]
    public void Parse_None_Success()
    {
        Option<DayOfWeek> dayOfWeek = Exercises.Parse<DayOfWeek>("Freeday");
        Assert.AreEqual(None, dayOfWeek);
    }

    [TestMethod]
    public void Lookup_Some_Success()
    {
        static bool isOdd(int i) => i % 2 == 1;
        Option<int> actual = new List<int> { 1 }.Lookup(isOdd);
        Assert.AreEqual(Some(1), actual);
    }

    [TestMethod]
    public void Lookup_None_Success()
    {
        static bool isOdd(int i) => i % 2 == 1;
        Option<int> actual = new List<int>().Lookup(isOdd);
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void EMail_Create_Some_Success()
    {
        const string Address = "barry_wallis@acm.org";
        Option<EMail> eMail = EMail.Create(Address);
        string actual = eMail.Match
        (
            () => string.Empty,
            (eMail) => eMail.Address
        );

        Assert.AreEqual(Address, actual);
    }

    [TestMethod]
    public void EMail_Create_Nome_Success()
    {
        const string Address = "barry@wallis@acm.org";
        Option<EMail> eMail = EMail.Create(Address);
        string actual = eMail.Match
        (
            () => string.Empty,
            (eMail) => eMail.Address
        );

        Assert.AreEqual(string.Empty, actual);
    }

    [TestMethod]
    public void EMail_Implicit_String_Success()
    {
        const string Address = "barry@wallis@acm.org";
        Option<EMail> eMail = EMail.Create(Address);
        string actual = eMail.Match
        (
            () => string.Empty,
            (eMail) => eMail
        );

        Assert.AreEqual(string.Empty, actual);
    }
}
