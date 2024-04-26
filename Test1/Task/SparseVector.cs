// <copyright file="SparseVector.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SparceVectorSpace;

/// <summary>
/// Sparce vector class.
/// </summary>
public class SparceVector
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SparceVector"/> class.
    /// </summary>
    /// <param name="coordinates">A list of integer arrays, where each array contains a coordinate (index, value) pair.</param>
    /// <param name="size">The size of the sparse vector.</param>
    /// <exception cref="ArgumentException">Thrown when the provided vector contains coordinates outside the specified size.</exception>
    public SparceVector(List<int[]> coordinates, int size)
    {
        this.Size = size;

        foreach (int[] i in coordinates)
        {
            this.Coordinates.Add(i[0], i[1]);
        }

        if (this.Coordinates.Count >= size)
        {
            throw new ArgumentException("The provided vector contains coordinates outside the specified size.");
        }
    }

    /// <summary>
    /// Gets coordinates of the vector.
    /// </summary>
    /// <value>Coordinates of the vector.</value>
    public Dictionary<int, int> Coordinates { get; private set; } = [];

    /// <summary>
    /// Gets the size of the vector.
    /// </summary>
    /// <value>The size of the vector.</value>
    public int Size { get; private set; } = 0;

    /// <summary>
    /// Gets or sets the value at the specified index.
    /// </summary>
    /// <param name="i">The index of the value.</param>
    /// <value>The value at the specified index.</value>
    public int this[int i]
    {
        get { return this.Coordinates.TryGetValue(i, out int coordinate) ? coordinate : 0; }
        set { this.Coordinates[i] = value; }
    }

    /// <summary>
    /// Adds the given sparse vector to this sparse vector.
    /// </summary>
    /// <param name="vector">The sparse vector to be added.</param>
    /// <exception cref="DifferentVectorsSizeException">Thrown when the sizes of the vectors are different.</exception>
    public void Add(SparceVector vector)
    {
        if (vector.Size != this.Size)
        {
            throw new DifferentVectorsSizeException("Vector sizes are different");
        }

        List<int> keys = this.Coordinates.Keys.Union(vector.Coordinates.Keys).ToList();

        foreach (int key in keys)
        {
            int value1 = this.Coordinates.TryGetValue(key, out int val1) ? val1 : 0;
            int value2 = vector.Coordinates.TryGetValue(key, out int val2) ? val2 : 0;
            this.Coordinates[key] = value1 + value2;

            if (this.Coordinates[key] == 0)
            {
                this.Coordinates.Remove(key);
            }
        }
    }

    /// <summary>
    /// Subtracts the given sparse vector from this sparse vector.
    /// </summary>
    /// <param name="vector">The sparse vector to be subtracted.</param>
    /// <exception cref="DifferentVectorsSizeException">Thrown when the sizes of the vectors are different.</exception>
    public void Subtract(SparceVector vector)
    {
        foreach (int key in vector.Coordinates.Keys)
        {
            vector.Coordinates[key] = -vector.Coordinates[key];
        }

        try
        {
            this.Add(vector);
        }
        catch (DifferentVectorsSizeException)
        {
            throw new DifferentVectorsSizeException("Vector sizes are different");
        }
    }

    /// <summary>
    /// Computes the scalar multiplication of this sparse vector with the given sparse vector.
    /// </summary>
    /// <param name="vector">The sparse vector to be multiplied with this vector.</param>
    /// <returns>The result of the scalar multiplication of this vector with the given vector.</returns>
    /// <exception cref="DifferentVectorsSizeException">Thrown when the sizes of the vectors are different.</exception>
    public int ScalarMultiplication(SparceVector vector)
    {
        if (vector.Size != this.Size)
        {
            throw new DifferentVectorsSizeException("Vector sizes are different");
        }

        List<int> keys = this.Coordinates.Keys.Union(vector.Coordinates.Keys).ToList();

        int result = 0;
        foreach (int key in keys)
        {
            int value1 = this.Coordinates.TryGetValue(key, out int val1) ? val1 : 0;
            int value2 = vector.Coordinates.TryGetValue(key, out int val2) ? val2 : 0;

            result += value1 * value2;
        }

        return result;
    }

    /// <summary>
    /// Checks if the sparse vector is zero.
    /// </summary>
    /// <returns>True if the sparse vector is zero, otherwise false.</returns>
    public bool IsZero()
    {
        return this.Coordinates.Count == 0;
    }
}
