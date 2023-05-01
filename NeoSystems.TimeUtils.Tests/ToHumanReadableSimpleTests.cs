using System;
using NUnit.Framework;
using NeoSystems.TimeUtils;

[TestFixture]
public class ToHumanReadableSimpleTests
{
    [TestCase(1, "one second")]
    [TestCase(45, "45 seconds")]
    [TestCase(60, "a minute")]
    [TestCase(90, "a minute")]
    [TestCase(121, "2 minutes")]
    [TestCase(3600, "an hour")]
    [TestCase(7200, "2 hours")]
    [TestCase(86400, "a day")]
    [TestCase(172800, "2 days")]
    [TestCase(2592000, "one month")]
    [TestCase(31104000, "one year")]
    [TestCase(91194000, "2 years")]

    public void TestToHumanReadableSimple(int time, string expected)
    {
        var ts = TimeSpan.FromSeconds(time);
        var actual = ts.ToHumanReadableSimple();
        Assert.AreEqual(expected, actual);
    }
}
