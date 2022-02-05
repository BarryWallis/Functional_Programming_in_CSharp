using System;
using System.Collections.Generic;
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
    public void MyTestMethod(int arg, bool expectedResult)
    {
        Func<int, bool> isMod2 = (int i) => i % 2 == 0;
        Func<int, bool>? negateIsMode2 = isMod2.Negate();
        bool actualResult = negateIsMode2(arg);
        Assert.AreEqual(expectedResult, actualResult);
    }
}
