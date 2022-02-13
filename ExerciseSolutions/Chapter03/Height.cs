namespace ExerciseSolutions.Chapter03;

public record Height
{
    public decimal Value { get; }
    public Height(decimal value) => Value = IsValid(value) ? value : throw new ArgumentException($"{value} is not a valid height",
                                                                                                 nameof(value));

    private static bool IsValid(decimal value) => value > 0;

    public static implicit operator decimal(Height height) => height.Value;
    public static explicit operator Height(decimal value) => new(value);
}