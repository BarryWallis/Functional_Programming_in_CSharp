
using LaYumba.Functional;

using static LaYumba.Functional.F;

using Enum = System.Enum;

namespace ExerciseSolutions.Chapter05;
public static class Exercises
{
    /// <summary>
    /// 1 Write a generic function that takes a string and parses it as a value of an enum. It
    /// should be usable as follows:
    /// Enum.Parse<DayOfWeek>("Friday") // => Some(DayOfWeek.Friday)
    /// Enum.Parse<DayOfWeek>("Freeday") // => None
    /// (T, string) -> Option<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="theString"></param>
    /// <returns></returns>
    public static Option<T> Parse<T>(this string theString) where T : struct
        => Enum.TryParse(theString, out T result) ? Some(result) : None;

    /// <summary>
    /// 2 Write a Lookup function that will take an IEnumerable and a predicate, and
    /// return the first element in the IEnumerable that matches the predicate, or None
    /// if no matching element is found. 
    /// Write its signature in arrow notation: (IEnumberable<T>, Func<T, bool>) -> Option<T>
    /// bool isOdd(int i) => i % 2 == 1;
    /// new List<int>().Lookup(isOdd) // => None
    /// new List<int> { 1 }.Lookup(isOdd) // => Some(1)
    /// </summary>
    /// <typeparam name="T">The type of the element to look up.</typeparam>
    /// <param name="ts">The list of elements.</param>
    /// <param name="predicate">The selection function.</param>
    /// <returns>The first element that meets the selection function.</returns>
    public static Option<T> Lookup<T>(this IEnumerable<T> ts, Func<T, bool> predicate)
        => !ts.Any(predicate) ? None : ts.First(predicate);


    // 3 Write a type Email that wraps an underlying string, enforcing that it’s in a valid
    // format. Ensure that you include the following:
    // - A smart constructor
    // - Implicit conversion to string, so that it can easily be used with the typical API
    // for sending emails
    // See EMail.cs
}
