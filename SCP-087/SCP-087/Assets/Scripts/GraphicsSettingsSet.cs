// <copyright file="GraphicsSettingsSet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// Sets graphics settings.
/// </summary>
public class GraphicsSettingsSet : MonoBehaviour
{
    [SerializeField]
    private int fpsLock = -1;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = this.fpsLock;
    }
}
