namespace ExerciseSolutions.Chapter03;

public record Weight
{
    public decimal Value { get; }
    public Weight(decimal value) => Value = IsValid(value) ? value : throw new ArgumentException($"{value} is not a valid age",
                                                                                                 nameof(value));

    private static bool IsValid(decimal value) => value > 0;

    public static implicit operator decimal(Weight weight) => weight.Value;
    public static explicit operator Weight(decimal value) => new(value);
}