// See https://aka.ms/new-console-template for more information
using ExerciseSolutions.Chapter03;

using static ExerciseSolutions.Chapter03.BmiCalculator;

namespace ExerciseSolutions.Chapter02;

internal class Program
{
    private static void Main() => Calculate();


    /// <summary>
    /// Get height and weight from the user, convert to metric and display resulting BMI information.
    /// </summary>
    public static void Calculate()
    {
        Height height = (Height)Prompt<decimal>("Height in feet: ", Console.Write, Console.ReadLine).ConvertFeetToMeters();
        Weight weight = (Weight)Prompt<decimal>("Weight in pounds: ", Console.Write, Console.ReadLine).ConvertPoundsToKilograms();
        decimal bmi = CalculateBmi(height, weight);
        string bmiRange = CalculateBmiRange(bmi);
        OutputBmiMessage(bmi, bmiRange, Console.WriteLine);
    }

}