using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace ExerciseSolutions.Chapter08;

public static class Exercises
{
    /// <summary>
    /// 1. Write a `ToOption` extension method to convert an `Either` into an
    /// `Option`. (Tip: start by writing
    /// the function signatures in arrow notation)
    /// </summary>
    /// <typeparam name="L">The Left type of Either.</typeparam>
    /// <typeparam name="R">The Right type of Either.</typeparam>
    /// <param name="either">The source to change to an Option.</param>
    public static Option<R> ToOption<L, R>(this Either<L, R> either) => either.Match(l => None, r => Some(r));

    /// <summary>
    /// 1. Then write a `ToEither` method to convert an `Option` into an
    /// `Either`, with a suitable parameter that can be invoked to obtain the
    /// appropriate `Left` value, if the `Option` is `None`. 
    /// </summary>
    /// <typeparam name="L">THe Left type of Either.</typeparam>
    /// <typeparam name="R">The Right type of either.</typeparam>
    /// <param name="option">The Option to convert.</param>
    /// <param name="left">The function to evaluate</param>
    /// <returns>The Either with the <paramref name="left"/> function as the Left value if the option is None 
    /// or the value of the Option if the Option is Some.</returns>
    public static Either<L, R> ToEither<L, R>(this Option<R> option, Func<L> left) 
        => option.Match<Either<L, R>>(() => left(), r => r);

    /// <summary>
    /// 2. Take a workflow where 2 or more functions that return an `Option`
    /// are chained using `Bind`.
    /// </summary>
    /// <param name="x">A dividend.</param>
    /// <param name="y">a divisor.</param>
    /// <returns>The square root of x/y. </returns>
    public static Option<double> Divide(int dividend, int divisor) => divisor == 0 ? None : Some((double)dividend / divisor);
    public static Option<double> SquareRoot(this double x) => double.IsNaN(Math.Sqrt(x)) ? None : Some(Math.Sqrt(x));
    public static Option<double> Exercise2a(int x, int y) => Divide(x, y).Bind(SquareRoot);

    // Then change the first one of the functions to return an `Either`.
    // This should cause compilation to fail. Since `Either` can be
    // converted into an `Option` as we have done in the previous exercise,
    // write extension overloads for `Bind`, so that
    // functions returning `Either` and `Option` can be chained with `Bind`,
    // yielding an `Option`.
    public static Either<string, double> Divide2b(int dividend, int divisor) 
        => divisor == 0 ? "Divide by zero error" : (double)dividend / divisor;
    public static Option<R> Bind<L, R>(this Either<L, R> either) => either.Match(either => None, r => Some(r));
    public static Option<double> Exercise2b(int x, int y) => Divide2b(x, y).Bind().Bind(SquareRoot);

    // 3. Write a function `Safely` of type ((() → R), (Exception → L)) → Either<L, R> that will
    // run the given function in a `try/catch`, returning an appropriately
    // populated `Either`.
    // Safely: 
    public static Either<L,R> Safely<L, R>(Func<R> f, Func<Exception, L> left)
    {
        try
        {
            return f();
        }
        catch (Exception ex)
        {
            return left(ex);
        }
    }

    // 4. Write a function `Try` of type (() → T) → Exceptional<T> that will
    // run the given function in a `try/catch`, returning an appropriately
    // populated `Exceptional`.
    public static Exceptional<T> Try<T>(Func<T> f)
    {
        try
        {
            return f();
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
