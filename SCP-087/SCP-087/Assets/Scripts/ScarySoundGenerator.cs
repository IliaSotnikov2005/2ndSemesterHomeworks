// <copyright file="ScarySoundGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections;
using UnityEngine;

/// <summary>
/// Generates scary sound on each floor.
/// </summary>
public class ScarySoundGenerator : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;
    [SerializeField]
    private AudioSource audioSource;

    private bool audioActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !this.audioActive)
        {
            this.audioSource.clip = this.audioClips[Random.Range(0, this.audioClips.Length)];
            this.audioSource.Play();
            this.StartCoroutine(this.Timer());
        }
    }

    private IEnumerator Timer()
    {
        this.audioActive = true;
        yield return new WaitForSeconds(this.audioClips[Random.Range(0, this.audioClips.Length)].length);
        this.audioActive = false;
    }
}
