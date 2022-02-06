using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static ExerciseSolutions.Chapter02.Chapter02Exercises;

namespace ExerciseTests.Chapter02;

[TestClass]
public class Chapter02Tests
{
    [TestMethod]
    [DataRow(4, false)]
    [DataRow(5, true)]
    public void Negate_Success(int arg, bool expectedResult)
    {
        Func<int, bool> isMod2 = (int i) => i % 2 == 0;
        Func<int, bool>? negateIsMode2 = isMod2.Negate();
        bool actualResult = negateIsMode2(arg);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void QuickSort_Success()
    {
        List<int> list = new() { -4, 1, 25, 50, 8, 10, 23 };
        List<int> expectedList = new() { -4, 1, 8, 10, 23, 25, 50 };
        List<int> sortedList = list.QuickSort();
        CollectionAssert.AreEqual(expectedList, sortedList);
    }

    [TestMethod]
    public void QuickSort_WithComparison_Success()
    {
        List<int> list = new() { -4, 1, 25, 50, 8, 10, 23 };
        List<int> expectedList = new() { -4, 1, 8, 10, 23, 25, 50 };
        List<int> sortedList = list.QuickSort((x, y) => x < y ? -1 : x == y ? 0 : 1);
        CollectionAssert.AreEqual(expectedList, sortedList);
    }
}
