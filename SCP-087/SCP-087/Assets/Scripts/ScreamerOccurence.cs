// <copyright file="ScreamerOccurence.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// Responsible for the appearance of the screamer object on the map.
/// </summary>
public class ScreamerOccurence : MonoBehaviour
{
    [SerializeField]
    private GameObject screamer;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Random.Range(1, 101) <= GlobalReferences.ScreamerChanse || this.activated)
            {
                this.activated = true;
                this.screamer.SetActive(true);
            }
        }
    }
}
