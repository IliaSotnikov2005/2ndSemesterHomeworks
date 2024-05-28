// <copyright file="HideScreamer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// Hides screamer object.
/// </summary>
public class HideScreamer : MonoBehaviour
{
    [SerializeField]
    private GameObject screamer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.screamer.SetActive(false);
        }
    }
}
