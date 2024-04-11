// <copyright file="DifferentVectorsSizeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// Thrown when the vectors passed to a method have different sizes.
/// </summary>
/// <param name="message">A custom error message.</param>
public class DifferentVectorsSizeException(string message) : Exception(message)
{
}