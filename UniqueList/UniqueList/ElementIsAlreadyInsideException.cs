// <copyright file="ElementIsAlreadyInsideException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UniqueList;

/// <summary>
/// Element is already inside the list exception.
/// </summary>
public class ElementIsAlreadyInsideException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ElementIsAlreadyInsideException"/> class.
    /// </summary>
    public ElementIsAlreadyInsideException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementIsAlreadyInsideException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ElementIsAlreadyInsideException(string message)
    : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementIsAlreadyInsideException"/> class with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="innerException"/> is null.</exception>
    public ElementIsAlreadyInsideException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}