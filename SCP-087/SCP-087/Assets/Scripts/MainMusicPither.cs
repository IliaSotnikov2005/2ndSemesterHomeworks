// <copyright file="MainMusicPither.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections;
using UnityEngine;

/// <summary>
/// Pithes main music on each floor.
/// </summary>
public class MainMusicPither : MonoBehaviour
{
    [SerializeField]
    private AudioSource mainTheme;

    private float targetPitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.targetPitch = Random.Range(0.5f, 2f);
            this.StartCoroutine(this.ChangePitchOverTime());
        }
    }

    private IEnumerator ChangePitchOverTime()
    {
        float startPitch = this.mainTheme.pitch;
        float timeElapsed = 0f;

        while (timeElapsed < 3)
        {
            this.mainTheme.pitch = Mathf.Lerp(startPitch, this.targetPitch, timeElapsed / 3);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        this.mainTheme.pitch = this.targetPitch;
    }
}
