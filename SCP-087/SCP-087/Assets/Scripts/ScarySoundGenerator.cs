using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource mainTheme;
    private float targetPitch;

    private bool audioActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audioActive)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            StartCoroutine(Timer());
            targetPitch = Random.Range(1f, 1.6f);
            StartCoroutine(ChangePitchOverTime());
        }
    }

    private IEnumerator Timer()
    {
        audioActive = true;
        yield return new WaitForSeconds(audioClips[Random.Range(0, audioClips.Length)].length);
        audioActive = false;
    }

    IEnumerator ChangePitchOverTime()
    {
        float startPitch = mainTheme.pitch;
        float timeElapsed = 0f;

        while (timeElapsed < 3)
        {
            mainTheme.pitch = Mathf.Lerp(startPitch, targetPitch, timeElapsed / 3);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        mainTheme.pitch = targetPitch;
    }
}
