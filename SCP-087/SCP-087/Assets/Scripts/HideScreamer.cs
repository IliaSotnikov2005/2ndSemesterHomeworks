using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScreamer : MonoBehaviour
{
    [SerializeField] GameObject screamer;
    [SerializeField] GameObject screamerTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            screamer.SetActive(false);
            screamerTrigger.SetActive(false);
        }
    }
}
