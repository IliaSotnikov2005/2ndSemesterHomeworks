// <copyright file="MoveToFrontTest.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MoveToFrontTest;

using MoveToFront;
using NUnit.Framework;

/// <summary>
/// Tests for the MoveToFrontAlgorithm class.
/// </summary>
public class Tests
{
    /// <summary>
    /// Test for the MoveToFrontAlgorithm class works correctly with mixed case letters.
    /// </summary>
    [Test]
    public void TestMixedCaseString()
    {
        string input = "AbCdEf";
        List<int> expectedResult = [0, 1, 2, 3, 4, 5];

        List<int> result = MoveToFrontAlghoritm.Run(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// Test for the MoveToFrontAlgorithm class throws exception with empty string.
    /// </summary>
    [Test]
    public void TestEmptyString()
    {
        string input = string.Empty;

        Assert.Throws<ArgumentNullException>(() => MoveToFrontAlghoritm.Run(input));
    }

    /// <summary>
    /// Test for the MoveToFrontAlgorithm class throws exception with null.
    /// </summary>
    [Test]
    public void TestNullString()
    {
        string? input = null;

        Assert.Throws<ArgumentNullException>(() => MoveToFrontAlghoritm.Run(input!));
    }

    /// <summary>
    /// Test for the MoveToFrontAlgorithm class throws exception when not English letters.
    /// </summary>
    [Test]
    public void TestNonEnglishLetter()
    {
        string input = "A#bCdEf";

        Assert.Throws<ArgumentException>(() => MoveToFrontAlghoritm.Run(input));
    }

    /// <summary>
    /// Test for the MoveToFrontAlgorithm class works correctly with upper case letters.
    /// </summary>
    [Test]
    public void TestUpperCaseString()
    {
        string input = "ABCDEF";
        List<int> expectedResult = [0, 1, 2, 3, 4, 5];

        List<int> result = MoveToFrontAlghoritm.Run(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// Test for the MoveToFrontAlgorithm class works correctly with lower case letters.
    /// </summary>
    [Test]
    public void TestLowerCaseString()
    {
        string input = "banana";
        List<int> expectedResult = [1, 1, 13, 1, 1, 1];

        List<int> result = MoveToFrontAlghoritm.Run(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// Test for the MoveToFrontAlgorithm class works correctly with duplicate characters.
    /// </summary>
    [Test]
    public void TestDublicatingString()
    {
        string input = "bbaaccb";
        List<int> expectedResult = [1, 0, 1, 0, 2, 0, 2];

        List<int> result = MoveToFrontAlghoritm.Run(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}