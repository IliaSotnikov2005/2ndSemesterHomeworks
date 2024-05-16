// <copyright file="Screamer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections;
using UnityEngine;

/// <summary>
/// Shows screamer on trigger enter and returns to the main menu.
/// </summary>
public class Screamer : MonoBehaviour
{
    [SerializeField]
    private GameObject screamer;
    [SerializeField]
    private GameObject screamerImage;
    [SerializeField]
    private AudioSource screamerAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.screamer.transform.LookAt(other.transform.position);
            this.screamer.transform.position = other.transform.position;
            this.screamerImage.SetActive(true);
            this.screamerAudio.Play();

            this.StartCoroutine(this.ReturnToMainMenu());
        }
    }

    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2f);

        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
