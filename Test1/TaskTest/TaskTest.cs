// <copyright file="TaskTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SparceVectorTest;
using SparceVectorSpace;

/// <summary>
/// Sparce vector test class.
/// </summary>
public class SparseVectorTests
{
    [Test]
    public void Constructor_ValidCoordinates_CreatesSparseVector()
    {
        List<int[]> coordinates = [[0, 1], [2, 2]];
        int size = 3;

        SparceVector sparseVector = new(coordinates, size);

        Assert.That(sparseVector.Size, Is.EqualTo(size));
        Assert.That(sparseVector.Coordinates.Count, Is.EqualTo(2));
        Assert.That(sparseVector[0], Is.EqualTo(1));
        Assert.That(sparseVector[2], Is.EqualTo(2));
    }

    [Test]
    public void Constructor_InvalidCoordinates_ThrowsArgumentException()
    {
        List<int[]> coordinates = [[0, 1], [3, 2]];
        int size = 1;

        Assert.Throws<ArgumentException>(() => new SparceVector(coordinates, size));
    }

    [Test]
    public void Add_SameSizeVectors_AddsCorrectly()
    {
        SparceVector vector1 = new ([[0, 1], [2, 2]], 3);
        SparceVector vector2 = new ([[0, 2], [2, 1]], 3);

        vector1.Add(vector2);

        Assert.That(vector1.Coordinates[0], Is.EqualTo(3));
        Assert.That(vector1.Coordinates[2], Is.EqualTo(3));
    }

    [Test]
    public void Add_DifferentSizeVectors_ThrowsDifferentVectorsSizeException()
    {
        SparceVector vector1 = new([[0, 1], [2, 2]], 3);
        SparceVector vector2 = new([[0, 2], [3, 1]], 4);

        Assert.Throws<DifferentVectorsSizeException>(() => vector1.Add(vector2));
    }

    [Test]
    public void Subtract_SameSizeVectors_SubtractsCorrectly()
    {
        SparceVector vector1 = new([[0, 1], [2, 2]], 3);
        SparceVector vector2 = new([[0, 2], [2, 1]], 3);

        vector1.Subtract(vector2);

        Assert.That(vector1[0], Is.EqualTo(-1));
        Assert.That(vector1[2], Is.EqualTo(1));
    }

    [Test]
    public void Subtract_DifferentSizeVectors_ThrowsDifferentVectorsSizeException()
    {
        SparceVector vector1 = new([[0, 1], [2, 2]], 3);
        SparceVector vector2 = new([[0, 2], [3, 1]], 4);

        Assert.Throws<DifferentVectorsSizeException>(() => vector1.Subtract(vector2));
    }

    [Test]
    public void ScalarMultiplication_SameSizeVectors_MultipliesCorrectly()
    {
        SparceVector vector1 = new([[0, 1], [2, 3]], 3);
        SparceVector vector2 = new([[0, 2], [2, 1]], 3);

        int result = vector1.ScalarMultiplication(vector2);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void ScalarMultiplication_DifferentSizeVectors_ThrowsDifferentVectorsSizeException()
    {
        SparceVector vector1 = new ([[0, 1], [2, 2]], 3);
        SparceVector vector2 = new ([[0, 2], [3, 1]], 4);

        Assert.Throws<DifferentVectorsSizeException>(() => vector1.ScalarMultiplication(vector2));
    }

    [Test]
    public void IsZero_ZeroVector_ReturnsTrue()
    {
        SparceVector sparseVector = new([], 3);

        bool result = sparseVector.IsZero();

        Assert.IsTrue(result);
    }

    [Test]
    public void IsZero_NonZeroVector_ReturnsFalse()
    {
        SparceVector sparseVector = new ([[0, 1], [2, 2]], 3);

        bool result = sparseVector.IsZero();

        Assert.IsFalse(result);
    }
}
