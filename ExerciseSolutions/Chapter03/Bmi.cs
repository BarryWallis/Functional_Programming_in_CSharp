namespace ExerciseSolutions.Chapter03;
public record Bmi
{
    public decimal Value { get; }

    public Bmi(decimal value) => Value = IsValid(value) ? value : throw new ArgumentException($"{value} is not a valid BMI",
                                                                                              nameof(value));
    private static bool IsValid(decimal value) => value > 0;

    public static implicit operator decimal(Bmi bmi) => bmi.Value;
    public static explicit operator Bmi(decimal value) => new(value);
}
