// <copyright file="FileIsEmptyException.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// File is empty exception.
/// </summary>
public class FileIsEmptyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileIsEmptyException"/> class.
    /// </summary>
    public FileIsEmptyException()
    : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileIsEmptyException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public FileIsEmptyException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileIsEmptyException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="innerException">Inner exception.</param>
    public FileIsEmptyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}