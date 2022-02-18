using System;
using System.Collections.Generic;
using System.Linq;

using ExerciseSolutions.Chapter06;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static LaYumba.Functional.F;

namespace ExerciseTests.Chapter06;
[TestClass]
public class Tests
{
    private static readonly WorkPermit _workPermitUnexpired = new(Number: "1", Expiry: DateTime.Today.AddDays(-10));
    private static readonly WorkPermit _workPermitExpired = new(Number: "2", Expiry: DateTime.Today.AddDays(10));
    private static readonly Employee _employeeWorkPermitExpired = new(Id: "12345",
                                      JoinedOn: DateTime.Today.AddYears(-5),
                                      LeftOn: DateTime.Today.AddYears(-2),
                                      WorkPermit: _workPermitExpired);
    private static readonly Employee _employeeWorkPermitNone = new(Id: "67890",
                                      JoinedOn: DateTime.Today.AddYears(-2),
                                      LeftOn: None,
                                      WorkPermit: None);
    private static readonly Employee _employeeWorkPermitUnexpired = new(Id: "24680",
                                     JoinedOn: DateTime.Today.AddYears(-5),
                                     LeftOn: DateTime.Today.AddYears(-4),
                                     WorkPermit: _workPermitUnexpired);
    private static readonly Dictionary<string, Employee> _employees = new() { ["12345"] = _employeeWorkPermitExpired, ["24680"] = _employeeWorkPermitUnexpired, ["67890"] = _employeeWorkPermitNone };

    [TestMethod]
    public void Map_Success()
    {
        List<int> expected = new() { 2, 4, 6 };

        ISet<int> vs = new HashSet<int>(Enumerable.Range(1, 3));
        IEnumerable<int> actual = vs.Map(v => v * 2);

        CollectionAssert.AreEqual(actual.ToList(), expected);
    }

    [TestMethod]
    public void MapOption_Some_Success()
    {
        LaYumba.Functional.Option<int> actual = Some(5).Map(i => i * 2);
        Assert.AreEqual(Some(10), actual);
    }

    [TestMethod]
    public void MapOption_None_Success()
    {
        LaYumba.Functional.Option<int> actual = None;
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void MapIEnumberable_Success()
    {
        List<int> expected = new() { 2, 4, 6 };

        IEnumerable<int> source = Enumerable.Range(1, 3);
        IEnumerable<int> actual = source.Map(i => i * 2);

        CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
    }

    [TestMethod]
    public void GetWorkPermit_NoEmployeeId_Success()
    {
        LaYumba.Functional.Option<WorkPermit> actual = Exercises.GetWorkPermit(_employees, "1234");
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void GetWorkPermit_EmployeeId_NoWorkPermit_Success()
    {
        LaYumba.Functional.Option<WorkPermit> actual = Exercises.GetWorkPermit(_employees, _employeeWorkPermitNone.Id);
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void GetWorkPermit_EmployeeId_WorkPermit_Unexpired_Success()
    {
        LaYumba.Functional.Option<WorkPermit> actual = Exercises.GetWorkPermit(_employees, _employeeWorkPermitUnexpired.Id);
        Assert.AreEqual(Some(_workPermitUnexpired), actual);
    }

    [TestMethod]
    public void GetWorkPermit_WorkPermitExpired_Success()
    {
        LaYumba.Functional.Option<WorkPermit> actual = Exercises.GetWorkPermit(_employees, _employeeWorkPermitExpired.Id);
        Assert.AreEqual(None, actual);
    }

    [TestMethod]
    public void AverageYearsWorkedAtTheCompany_Success()
    {
        List<Employee> employees = new() { _employeeWorkPermitExpired, _employeeWorkPermitNone, _employeeWorkPermitUnexpired };
        double actual = Exercises.AverageYearsWorkedAtTheCompany(employees);
        Assert.AreEqual(2, actual);
    }
}