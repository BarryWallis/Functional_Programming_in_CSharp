using System;
using System.Globalization;

using ExerciseSolutions.Chapter03;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static ExerciseSolutions.Chapter03.BmiCalculator;

namespace ExerciseTests.Chapter03;
[TestClass]
public class BmiTests
{
    [TestMethod]
    public void Height_Success()
    {
        const decimal Expected = 5.75M;
        Height actual = new(Expected);
        Assert.AreEqual(Expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Height_ArgumentException()
    {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        Height height = new(-1);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
    }

    [TestMethod]
    public void Weight_Success()
    {
        const decimal Expected = 5.75M;
        Weight actual = new(Expected);
        Assert.AreEqual(Expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Weight_ArgumentException()
    {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        Weight height = new(-1);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
    }

    [TestMethod]
    public void ConvertFeetToMeters_Success()
    {
        const decimal Feet = 5.75M;
        const decimal Expected = 1.7526M;
        decimal actual = Feet.ConvertFeetToMeters();

        Assert.AreEqual(Expected, actual);
    }

    [TestMethod]
    public void ConvertPoundsToKilograms_Success()
    {
        const decimal Pounds = 158.5M;
        const decimal Expected = 71.894390645M;
        decimal actual = Pounds.ConvertPoundsToKilograms();

        Assert.AreEqual(Expected, actual);
    }

    private const string PromptString = "Enter a decimal number: ";
    private const decimal PromptValue = 5.75M;

    [TestMethod]
    public void Prompt_Success()
    {
        decimal actual = Prompt<decimal>(PromptString, Writer, Reader);
        Assert.AreEqual(PromptValue, actual);
    }

    private void Writer(string prompt) => Assert.AreEqual(PromptString, prompt);

    private string? Reader() => PromptValue.ToString(CultureInfo.InvariantCulture);

    [TestMethod]
    public void CalculateBmi_Success()
    {
        const decimal Weight = 37.25M;
        const decimal Height = 3.458333333333333M;
        const decimal Expected = 15.206469352044527894274385026M;
        decimal actual = CalculateBmi(new Height(Height.ConvertFeetToMeters()), new Weight(Weight.ConvertPoundsToKilograms()));
        Assert.AreEqual(Expected, actual);
    }

    [TestMethod]
    [DataRow(18.0, "Underweight")]
    [DataRow(25.0, "Overweight")]
    [DataRow(20.0, "Healthy Weight")]
    public void CalculateBmiRange_Success(double bmi, string expected)
    {
        string actual = CalculateBmiRange((decimal)bmi);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void OutputBmiMessage_Success()
    {
        const decimal Bmi = 20M;
        const string Excpected = "BMI 20 is Healthy Weight";
        string actual = string.Empty;
        OutputBmiMessage(Bmi, "Healthy Weight", p => actual = p);
        Assert.AreEqual(Excpected, actual);
    }
}
