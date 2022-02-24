using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExerciseSolutions.Chapter08;
using static ExerciseSolutions.Chapter08.Exercises;

using LaYumba.Functional;
using static LaYumba.Functional.F;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace ExerciseTests.Chapter08;

[TestClass]
public class MyTestClass
{
    [TestMethod]
    public void ToOption_Return_None()
    {
        Either<string, int> either = "Left";
        Option<int> option = either.ToOption();
        Assert.AreEqual(option, None);
    }

    [TestMethod]
    public void ToOption_Return_Some()
    {
        Either<string, int> either = 1;
        Option<int> option = either.ToOption();
        Assert.AreEqual(option, Some(1));
    }

    [TestMethod]
    public void ToEither_Return_Left()
    {
        Option<int> option = None;
        Either<string, int> either = option.ToEither(() => "test");
        Assert.AreEqual(either, "test");
    }

    [TestMethod]
    public void ToEither_Return_Right()
    {
        Option<int> option = Some(1);
        Either<string, int> either = option.ToEither(() => "test");
        Assert.AreEqual(either, 1);
    }

    [TestMethod]
    public void Exercise2a_None()
    {
        Option<double> actual = Exercise2a(2, 0);
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void Exercise2a_Some()
    {
        Option<double> actual = Exercise2a(18, 2);
        Assert.AreEqual(3, actual);
    }

    [TestMethod]
    public void Divide_Success()
    {
        Option<double> result = Divide(18, 2);
        Assert.AreEqual(9, result);
    }

    [TestMethod]
    public void Divide_None()
    {
        Option<double> result = Divide(18, 0);
        Assert.AreEqual(None, result);
    }

    [TestMethod]
    public void Exercise2b_None()
    {
        Option<double> actual = Exercise2b(2, 0);
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void Exercise2b_Some()
    {
        Option<double> actual = Exercise2b(18, 2);
        Assert.AreEqual(3, actual);
    }

    [TestMethod]
    public void Safely_Right()
    {
        Either<string, int> actual = Safely(() => 13, ex => ex.Message);
        Assert.AreEqual(13, actual);
    }

    [TestMethod]
    public void Safely_Left()
    {
        Either<string, int> actual = Safely<string, int>(() => throw new ArgumentNullException(), ex => ex.Message);
        Assert.AreEqual("Value cannot be null.", actual);
    }

    [TestMethod]
    public void Try_Success()
    {
        Exceptional<int> exceptional = Exercises.Try(() => 1);
        int actual = exceptional.Match(Exception: e => throw e, Success: i => i);
        Assert.AreEqual(1, actual);
    }

    [TestMethod]
    public void Try_Exception()
    {
        static int f() => throw new NotImplementedException();

        string actual = Exercises
                        .Try(f).Match(Exception: e => e.Message, Success: i => i.ToString(CultureInfo.InvariantCulture));
        Assert.AreEqual("The method or operation is not implemented.", actual);
    }
}