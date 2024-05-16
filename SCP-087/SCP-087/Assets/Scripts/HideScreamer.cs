using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScreamer : MonoBehaviour
{
    [SerializeField] private GameObject screamer;
    [SerializeField] private GameObject screamerTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screamer.SetActive(false);
            screamerTrigger.SetActive(false);
        }
    }
}
