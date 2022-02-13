using System.Globalization;

namespace ExerciseSolutions.Chapter03;

// 1. Write a console app that calculates a user's Body-Mass Index:
//   - prompt the user for her height in metres and weight in kg
//   - calculate the BMI as weight/height^2
//   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
// 2. Structure your code so that the pure and impure parts are separate
// 3. Unit test the pure parts
// 4. Unit test the impure parts using the HOF-based approach
public static class BmiCalculator
{
    public delegate void Writer(string prompt);
    public delegate string? Reader();

    private const decimal UnderWeight = 18.5M;
    private const decimal OverWeight = 25.0M;

    /// <summary>
    /// Convert feet to meters.
    /// </summary>
    /// <param name="feet">The feet to convert.</param>
    /// <returns>The feet converted to meters.</returns>
    public static decimal ConvertFeetToMeters(this decimal feet) => feet * 0.3048M;

    /// <summary>
    /// Convert pounds to kilograms.
    /// </summary>
    /// <param name="pounds">The weight in pounds.</param>
    /// <returns>The weight in kilgorams.</returns>
    public static decimal ConvertPoundsToKilograms(this decimal pounds) => pounds * 0.45359237M;

    /// <summary>
    /// Output the BMI message.
    /// </summary>
    /// <param name="bmi">The BMI.</param>
    /// <param name="bmiRange">An indication of the BMI range.</param>
    /// <param name="writer">A function to write the output.</param>
    public static void OutputBmiMessage(decimal bmi, string bmiRange, Writer writer) => writer($"BMI {bmi} is {bmiRange}");

    /// <summary>
    /// Determine the status of the given BMI.
    /// </summary>
    /// <param name="bmi">The BMI to check.</param>
    /// <returns>The ststus of the given BMI.</returns>
    public static string CalculateBmiRange(decimal bmi) => bmi < UnderWeight
                                                           ? "Underweight"
                                                           : bmi >= OverWeight
                                                             ? "Overweight"
                                                             : "Healthy Weight";

    /// <summary>
    /// Calculate the BMI from the given height and weight.
    /// </summary>
    /// <param name="height">The height in meters.</param>
    /// <param name="weight">The weight in kilograms.</param>
    /// <returns>The BMI.</returns>
    public static decimal CalculateBmi(Height height, Weight weight) => weight / (height * height);

    /// <summary>
    ///Write a prompt to the user and return a value of the given type.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="prompt"></param>
    /// <param name="writer"></param>
    /// <param name="reader"></param>
    /// <returns></returns>
    public static T? Prompt<T>(string prompt, Writer writer, Reader reader) where T : IConvertible
    {
        writer(prompt);
        string value = reader() ?? "";
        return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
    }
}