using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;

    private bool audioActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audioActive)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        audioActive = true;
        yield return new WaitForSeconds(audioClips[Random.Range(0, audioClips.Length)].length);
        audioActive = false;
    }
}
