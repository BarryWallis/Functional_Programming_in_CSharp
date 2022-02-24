namespace ExerciseSolutions.Chapter07;
public static class Exercises
{
    // 1. Without looking at any code or documentation (or intllisense), write the function signatures of
    // `OrderByDescending`, `Take` and `Average`, which we used to implement `AverageEarningsOfRichestQuartile`:
    //static decimal AverageEarningsOfRichestQuartile(List<Person> population)
    //   => population
    //      .OrderByDescending(p => p.Earnings)
    //      .Take(population.Count / 4)
    //      .Select(p => p.Earnings)
    //      .Average();
    // OrderByDescending: (IEnumerable<T>, T -> IComparable<T>) -> IEnumberable<T>
    // Take: (IEnumberable<T>, int) -> IEnumberable<T>
    // Select: (IEnumerable<T>, T -> IComperable<T>) -> IEnumerable<T>
    // Average: IEnumberable<T> -> double

    // 2 Check your answer with the MSDN documentation: https://docs.microsoft.com/
    // en-us/dotnet/api/system.linq.enumerable. How is Average different?

    // 3 Implement a general purpose Compose function that takes two unary functions
    // and returns the composition of the two.
    public static Func<T, R2> Compose<T, R, R2>(Func<R, R2> f, Func<T, R> g) => x => f(g(x));
}
