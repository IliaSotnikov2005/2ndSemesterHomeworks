// <copyright file="Teleport.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// Teleports player to the given height.
/// </summary>
public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Teleport target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(pos.x, this.target.gameObject.transform.position.y, pos.z);
        }
    }
}