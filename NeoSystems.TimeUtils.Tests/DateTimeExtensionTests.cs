
using System;
using NUnit.Framework;
using NeoSystems.TimeUtils;
using System.Globalization;

namespace NeoSystems.TimeUtils.Tests;

public class DateTimeExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void ToUnixTime_WhenGivenValidDateTime_ReturnsUnixTimeStampValue()
    {
        // Arrange
        DateTime expectedDate = new DateTime(2020, 8, 15);

        // Act
        long actualUnixTimeStampValue = expectedDate.ToUnixTime();

        // Assert
        Assert.AreEqual(1597449600, actualUnixTimeStampValue);
    }

    // unix milliseconds Test 1: 
    [Test]
    public void ToUnixTimeMilliseconds_ValidDateTime_ReturnsCorrectUnixTimeMilliseconds()
    {
        // Arrange
        DateTime expectedDate = new DateTime(2020, 8, 15);

        // Act
        long actualUnixTimeStampValue = expectedDate.ToUnixTimeMilliseconds();

        // Assert
        Assert.AreEqual(1597449600000, actualUnixTimeStampValue);
    }
}
