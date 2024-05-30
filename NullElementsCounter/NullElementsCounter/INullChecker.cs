// <copyright file="INullChecker.cs" company="IlyaSotnikov">
// Copyright (c) IlyaSotnikov. All rights reserved.
// </copyright>

namespace NullElementsCounter;

public interface INullChecker<T>
{
    public bool IsNull(T element);
}