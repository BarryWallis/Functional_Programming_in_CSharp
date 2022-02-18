
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace ExerciseSolutions.Chapter06;
public static class Exercises
{
    /// <summary>
    /// 1 Implement Map for ISet<T> and IDictionary<K, T>. (Tip: start by writing down
    /// the signature in arrow notation.)
    /// 
    /// Map: (ISet<T>, Func<T, R>) -> IEnumberable<R>
    /// </summary>
    /// <typeparam name="T">The type of ISet.</typeparam>
    /// <typeparam name="R">The return type of the IEnumberable.</typeparam>
    /// <param name="ts">The ISet.</param>
    /// <param name="f">The function to aply to every member of the ISet.</param>
    /// <returns></returns>
    public static IEnumerable<R> Map<T, R>(this ISet<T> ts, Func<T, R> f)
    {
        foreach (T t in ts)
        {
            yield return f(t);
        }
    }

    /// <summary>
    /// 2 Implement Map for Option in terms of Bind and Return.
    ///
    /// Map: (Option<T>, Func<T, R>) -> Option<R>
    /// </summary>
    /// <typeparam name="T">The type of Option to map.</typeparam>
    /// <typeparam name="R">The Option return type.</typeparam>
    /// <param name="option">The option to map.</param>
    /// <param name="f">The function to map the Option.</param>
    /// <returns>The resulting Option.</returns>
    public static Option<R> Map<T, R>(this Option<T> option, Func<T, R> f)
        => option.Bind<T, R>(t => f(t)).Match(() => None, (r) => Some(r));

    /// <summary>
    /// 2 Implement Map for IEnumerable in terms of Bind and Return.
    ///
    /// Map: (IEnumerable<T>, Funct<T, R>) -> IEnumerable<R>.
    /// </summary>
    /// <typeparam name="T">The type of IEnumerable to map.</typeparam>
    /// <typeparam name="R">The IEnumerable return type.</typeparam>
    /// <param name="ts">The IEnumerable to map.</param>
    /// <param name="f">The function to map the IEnumberable.</param>
    /// <returns>The resulting Option.</returns>
    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f)
        => ts.Bind<T, R>(t => f(t)).ToList();

    /// <summary>
    /// 3 Use Bind and an Option-returning Lookup function (such as the one we defined
    /// in chapter 3) to implement GetWorkPermit. 
    /// Then enrich the implementation so that `GetWorkPermit`
    /// returns `None` if the work permit has expired.
    /// </summary>
    /// <param name="people">The dictionary of employees.</param>
    /// <param name="employeeId">The employee to look up.</param>
    /// <returns>The optional work permit.</returns>
    public static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
    {
        Option<Employee> employee = people.Lookup(employeeId).Match
                  (
                       () => None,
                       (e) => Some(e)
                   );
        Option<WorkPermit> workPermit = employee.Match(() => None, e => e.WorkPermit);
        Option<WorkPermit> result = workPermit.Match(() => None, wp => wp.Expiry <= DateTime.Today ? Some(wp) : None);
        return result;
    }

    // 4 Use Bind to implement AverageYearsWorkedAtTheCompany, shown below (only
    // employees who have left should be included).

    public static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
        => employees.Bind(e => e.LeftOn.Map(lo => lo.Year - e.JoinedOn.Year)).Average();
}