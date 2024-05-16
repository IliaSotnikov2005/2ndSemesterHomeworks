using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Screamer : MonoBehaviour
{
    [SerializeField] private GameObject screamer;
    [SerializeField] private GameObject screamerImage;
    [SerializeField] private AudioSource screamerAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screamer.transform.LookAt(other.transform.position);
            screamer.transform.position = other.transform.position;
            screamerImage.SetActive(true);
            screamerAudio.Play();

            StartCoroutine(ReturnToMainMenu());
        }
    }

    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2f);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
