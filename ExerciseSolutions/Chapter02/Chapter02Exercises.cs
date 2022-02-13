namespace ExerciseSolutions.Chapter02;

public static class Chapter02Exercises
{
    /// <summary>
    /// 1. Write a function that negates a given predicate: whenvever the given predicate
    /// evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
    /// </summary>
    /// <typeparam name="T">The type of the item to evaluate.</typeparam>
    /// <param name="predicate">The predicate function to use to evaluate the item.</param>
    /// <returns>The logical negation of applying the predicte.</returns>
    public static Func<T, bool> Negate<T>(this Func<T, bool> predicate) => t => !predicate(t);

    /// <summary>
    /// 2. Write a method that uses quicksort to sort a `List<int>` and returns a new list,
    /// rather than sorting it in place).
    /// </summary>
    /// <param name="list">The list to sort.</param>
    /// <returns>The new sorted list.</returns>
    public static List<int> QuickSort(this List<int> list)
    {
        List<int> result;
        if (list.Count == 0)
        {
            result = new();
        }
        else
        {
            int pivot = list[0];
            IEnumerable<int> rest = list.Skip(1);
            List<int> left = rest.Where(t => t.CompareTo(pivot) <= 0).ToList();
            List<int> right = rest.Where(t => t.CompareTo(pivot) > 0).ToList();
            result = QuickSort(left).Append(pivot)
                                    .Concat(right.QuickSort())
                                    .ToList();
        }

        return result;
    }

    // 3. Generalize your implementation to take a `List<T>`, and additionally a 
    // `Comparison<T>` delegate.
    /// <summary>
    /// 3. Write a method that uses quicksort to sort a generic `List<T>` and returns a new list,
    /// rather than sorting it in place.
    /// </summary>
    /// <typeparam name="T">The type of objects in the list.</typeparam>
    /// <param name="list">The list to sort."</param>
    /// <param name="compare">The function used to compare the objcts in the list.</param>
    /// <returns></returns>
    public static List<T> QuickSort<T>(this List<T> list, Comparison<T> compare)
    {

        List<T> result;
        if (list.Count == 0)
        {
            result = new();
        }
        else
        {
            T pivot = list[0];
            IEnumerable<T> rest = list.Skip(1);
            List<T> left = rest.Where(t => compare(t, pivot) <= 0).ToList();
            List<T> right = rest.Where(t => compare(t, pivot) > 0).ToList();
            result = QuickSort(left, compare).Append(pivot)
                                    .Concat(right.QuickSort(compare))
                                    .ToList();
        }

        return result;
    }
}
