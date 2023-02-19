using System;
using NUnit.Framework;
using NeoSystems.TimeUtils;
using System.Globalization;

namespace NeoSystems.TimeUtils.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // Test cases

        // Tests that the return statements consider a delta of < 60 seconds
        Assert.AreEqual("one second", TimeSpan.FromSeconds(1).ToHumanReadableSimple());
        Assert.AreEqual("7 seconds", TimeSpan.FromSeconds(7).ToHumanReadableSimple());
        // Tests that the return statements consider a delta of > 60 seconds
        Assert.AreEqual("a minute", TimeSpan.FromMinutes(1).ToHumanReadableSimple());
        Assert.AreEqual("14 minutes", TimeSpan.FromMinutes(14).ToHumanReadableSimple());

    }

    [Test]
    public void ToHumanReadableExpandedTimeSpanTest()
    {
        TimeUnits units = new TimeUnits();
        TimeSpan expected = TimeSpan.FromMilliseconds(31536000000);

        Assert.AreEqual($"365 days", expected.ToHumanReadableExpanded(units));
    }

    [Test]
    public void AddMilliseconds_Zero_NoChangeInTimeSpan()
    {
        TimeSpan ts = new TimeSpan(1, 1, 1);
        TimeSpan res = ts.AddMilliseconds(0);

        Assert.AreEqual(ts, res);
    }

    [Test]
    public void AddMilliseconds_PositiveValue_ShouldAddToOriginalTimeSpan()
    {
        TimeSpan ts = new TimeSpan(1, 1, 1);
        TimeSpan res = ts.AddMilliseconds(20);

        Assert.IsTrue(res > ts);
    }

    [Test]
    public void AddMilliseconds_NegativeValue_ShouldSubtractFromOriginalTimeSpan()
    {
        TimeSpan ts = new TimeSpan(1, 1, 1);
        TimeSpan res = ts.AddMilliseconds(-20);

        Assert.IsTrue(res < ts);
    }

    // Test 1 - Basic Positive Input
    [Test]
    public void TestAddSeconds_positiveInput()
    {
        TimeSpan startTime = new TimeSpan(0, 0, 10);
        TimeSpan expectedTime = new TimeSpan(0, 0, 25);

        Assert.AreEqual(expectedTime, startTime.AddSeconds(15));
    }

    // Test 2 - Basic Negative Input
    [Test]
    public void TestAddSeconds_negativeInput()
    {
        TimeSpan startTime = new TimeSpan(0, 0, 10);
        TimeSpan expectedTime = new TimeSpan(0, 0, -5);

        Assert.AreEqual(expectedTime, startTime.AddSeconds(-15));
    }

    // Test 3 - TimeSpan exceeding 24 hours
    [Test]
    public void TestAddSeconds_exceedingDay()
    {
        TimeSpan startTime = new TimeSpan(20, 0, 0);
        TimeSpan expectedTime = new TimeSpan(21, 0, 0);

        Assert.AreEqual(expectedTime, startTime.AddSeconds(3600));
    }

    // Test adding positive minutes to TimeSpan
    [Test]
    public void AddMinutes_PositiveMinutes_AddsCorrectly()
    {
        TimeSpan ts = new TimeSpan(1, 2, 3);
        double minutes = 15;
        TimeSpan expected = new TimeSpan(1, 17, 3);

        TimeSpan actual = ts.AddMinutes(minutes);

        Assert.AreEqual(expected, actual);
    }

    // Test adding negative minutes to TimeSpan
    [Test]
    public void AddMinutes_NegativeMinutes_AddsCorrectly()
    {
        TimeSpan ts = new TimeSpan(1, 2, 3);
        double minutes = -15;
        TimeSpan expected = new TimeSpan(0, 47, 3);

        TimeSpan actual = ts.AddMinutes(minutes);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AddHours_01()
    {
        TimeSpan testTimeSpan = new TimeSpan(5, 30, 0);
        TimeSpan expectedTimeSpan = new TimeSpan(7, 30, 0);
        TimeSpan resultTimeSpan = testTimeSpan.AddHours(2);

        Assert.AreEqual(expectedTimeSpan, resultTimeSpan);
    }

    [Test]
    public void AddHours_02()
    {
        TimeSpan testTimeSpan = new TimeSpan(5, 30, 0);
        TimeSpan expectedTimeSpan = new TimeSpan(1, 30, 0);
        TimeSpan resultTimeSpan = testTimeSpan.AddHours(-4);

        Assert.AreEqual(expectedTimeSpan, resultTimeSpan);
    }

    [Test]
    public void AddDays_WorksForNegativeValue()
    {
        // Arrange 
        TimeSpan ts = new TimeSpan(3, 4, 5);

        // Act
        TimeSpan result = ts.AddDays(-1);

        // Assert
        Assert.AreEqual(-20, result.Hours);
        Assert.AreEqual(-55, result.Minutes);
        Assert.AreEqual(-55, result.Seconds);
    }

    [Test]
    public void AddDays_WorksForPositiveValue()
    {
        // Arrange 
        TimeSpan ts = new TimeSpan(3, 4, 5);

        // Act
        TimeSpan result = ts.AddDays(1);

        // Assert
        Assert.AreEqual(1, result.Days);
        Assert.AreEqual(3, result.Hours);
        Assert.AreEqual(4, result.Minutes);
        Assert.AreEqual(5, result.Seconds);
    }

    [Test]
    public void TimespanAddWeeks_ZeroWeeks_ReturnsSameValue()
    {
        TimeSpan given = TimeSpan.FromMinutes(30);
        TimeSpan expected = given;
        Assert.AreEqual(expected, given.AddWeeks(0));
    }

    // Test 2
    public void TimespanAddWeeks_PositiveWeeks_ReturnsExpectedValue()
    {
        TimeSpan given = TimeSpan.FromMinutes(30);
        TimeSpan expected = TimeSpan.FromDays(21);
        Assert.AreEqual(expected, given.AddWeeks(3));
    }

    [Test]
    public void AddMonthsTest()
    {
        TimeSpan ts = new TimeSpan(1, 2, 3, 4, 5);
        Assert.AreEqual(ts.Add(TimeSpan.FromDays(5 * 30)), ts.AddMonths(5));
    }

    [Test]
    public void AddMonthsIsPositiveTest()
    {
        TimeSpan ts = new TimeSpan(1, 2, 3, 4, 5);
        Assert.IsTrue(ts.AddMonths(5).Ticks > 0);
    }

    [Test]
    public void AddMonthsZeroTest()
    {
        TimeSpan ts = new TimeSpan(1, 2, 3, 4, 5);
        Assert.AreEqual(ts, ts.AddMonths(0));
    }

    [Test]
    public void AddYears_PositiveYear_CorrectlyIncrementsTimeSpan()
    {
        TimeSpan ts1 = new TimeSpan(10, 0, 0);
        TimeSpan expected = new TimeSpan(10, 0, 0).Add(TimeSpan.FromDays(10 * 365.25));

        TimeSpan actual = ts1.AddYears(10);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AddYears_NegativeYear_CorrectlyDecrementsTimeSpan()
    {
        TimeSpan ts1 = new TimeSpan(10, 0, 0);
        TimeSpan expected = new TimeSpan(10, 0, 0).Add(TimeSpan.FromDays(-10 * 365.25));

        TimeSpan actual = ts1.AddYears(-10);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToHumanReadableExpanded_TenthOfSecond_ReturnsTenthOfSecond()
    {
        // Arrange 
        TimeSpan ts = TimeSpan.FromMilliseconds(100);
        TimeUnits tu = new TimeUnits()
        {
            milliseconds = "milliseconds",
            seconds = "seconds",
            minutes = "minutes",
            hours = "hours",
            days = "days",
            years = "years"
        };

        // Act
        string result = ts.ToHumanReadableExpanded(tu);

        // Assert
        Assert.AreEqual("100 milliseconds", result);
    }

    //Test 2
    [Test]
    public void ToHumanReadableExpanded_OneSecond_ReturnsOneSecond()
    {
        // Arrange 
        TimeSpan ts = TimeSpan.FromSeconds(1);
        TimeUnits tu = new TimeUnits()
        {
            milliseconds = "milliseconds",
            seconds = "seconds",
            minutes = "minutes",
            hours = "hours",
            days = "days",
            years = "years"
        };

        // Act
        string result = ts.ToHumanReadableExpanded(tu);

        // Assert
        Assert.AreEqual("1 seconds", result);
    }

}


