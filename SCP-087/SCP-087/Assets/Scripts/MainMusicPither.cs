using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicPither : MonoBehaviour
{
    [SerializeField] private AudioSource mainTheme;

    private float targetPitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetPitch = Random.Range(0.5f, 2f);
            StartCoroutine(ChangePitchOverTime());
        }
    }

    private IEnumerator ChangePitchOverTime()
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
