using System;
using NUnit.Framework;
using NeoSystems.TimeUtils;
using System.Globalization;

namespace NeoSystems.TimeUtils.Tests;

public class DateTimeUtilsTests
{
    [SetUp]
    public void Setup()
    {
    }

    // Test One:
    [Test]
    public void FuzzyAdd_Years_Test()
    {
        DateTime d = DateTime.Now;
        int years = 5;
        string str = $"{years}Y";
        DateTime result = d.FuzzyAdd(str);
        Assert.AreEqual(d.AddYears(years), result);
    }

    // Test Two:
    [Test]
    public void FuzzyAdd_Months_Test()
    {
        DateTime d = DateTime.Now;
        int months = 5;
        string str = $"{months}M";
        DateTime result = d.FuzzyAdd(str);
        Assert.AreEqual(d.AddMonths(months), result);
    }

    // Test Three:
    [Test]
    public void FuzzyAdd_Days_Test()
    {
        DateTime d = DateTime.Now;
        int days = 5;
        string str = $"{days}D";
        DateTime result = d.FuzzyAdd(str);
        Assert.AreEqual(d.AddDays(days), result);
    }

    // Test Four:
    [Test]
    public void FuzzyAdd_Hours_Test()
    {
        DateTime d = DateTime.Now;
        int hours = 5;
        string str = $"{hours}h";
        DateTime result = d.FuzzyAdd(str);
        Assert.AreEqual(d.AddHours(hours), result);
    }

    // Test Five:
    [Test]
    public void FuzzyAdd_Minutes_Test()
    {
        DateTime d = DateTime.Now;
        int minutes = 5;
        string str = $"{minutes}m";
        DateTime result = d.FuzzyAdd(str);
        Assert.AreEqual(d.AddMinutes(minutes), result);
    }

    // Test Six:
    [Test]
    public void FuzzyAdd_Seconds_Test()
    {
        DateTime d = DateTime.Now;
        int seconds = 5;
        string str = $"{seconds}s";
        DateTime result = d.FuzzyAdd(str);
        Assert.AreEqual(d.AddSeconds(seconds), result);
    }

    // Test null
    [Test]
    public void FuzzyAdd_null()
    {
        DateTime d = DateTime.Now;
        DateTime result = d.FuzzyAdd(null);
        Assert.AreEqual(d, result);
    }

    // Test 1
    [Test]
    public void DateTimeFromUnixTimestampMillis_WithValidInput_ReturnsCorrectDateTime()
    {
        // Arrange
        long millis = 1577836800000; // Unix timestamp for 1 January 2020 12:00:00
        DateTime expected = new DateTime(2020, 1, 1, 0, 0, 0);

        // Act
        DateTime result = DateTimeUtils.DateTimeFromUnixTimestampMillis(millis);

        // Assert
        Assert.AreEqual(expected, result);
    }

    // Test 2
    [Test]
    public void DateTimeFromUnixTimestampMillis_WithZeroInput_ReturnsUnixEpoch()
    {
        // Arrange
        long millis = 0; // Unix Epoch
        DateTime unixEpoch = DateTimeUtils.UnixEpoch;

        // Act
        DateTime result = DateTimeUtils.DateTimeFromUnixTimestampMillis(millis);

        // Assert
        Assert.AreEqual(unixEpoch, result);
    }

    // Test 1
    [Test]
    public void DateTimeFromUnixTimestampSeconds_WithValidInput_ReturnsCorrectDateTime()
    {
        // Arrange
        long millis = 1577836800; // Unix timestamp for 1 January 2020 12:00:00
        DateTime expected = new DateTime(2020, 1, 1, 0, 0, 0);

        // Act
        DateTime result = DateTimeUtils.DateTimeFromUnixTimestampSeconds(millis);

        // Assert
        Assert.AreEqual(expected, result);
    }

    // Test 2
    [Test]
    public void DateTimeFromUnixTimestampSeconds_WithZeroInput_ReturnsUnixEpoch()
    {
        // Arrange
        long millis = 0; // Unix Epoch
        DateTime unixEpoch = DateTimeUtils.UnixEpoch;

        // Act
        DateTime result = DateTimeUtils.DateTimeFromUnixTimestampSeconds(millis);

        // Assert
        Assert.AreEqual(unixEpoch, result);
    }

}