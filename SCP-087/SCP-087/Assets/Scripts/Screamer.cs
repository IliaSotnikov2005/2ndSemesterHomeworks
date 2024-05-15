using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Screamer : MonoBehaviour
{
    [SerializeField] GameObject babai;
    [SerializeField] GameObject screamerImage;
    [SerializeField] AudioSource screamerAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 direction = (other.transform.position - babai.transform.position).normalized;
            babai.transform.LookAt(other.transform.position);
            babai.transform.position = other.transform.position;
            screamerImage.SetActive(true);
            screamerAudio.Play();

            StartCoroutine(ReturnToMainMenu());
        }
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2f);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
