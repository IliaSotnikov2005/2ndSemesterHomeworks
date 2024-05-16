using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerOccurence : MonoBehaviour
{
    [SerializeField] private GameObject screamer;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Random.Range(1, 101) <= GlobalReferences.ScreamerChanse || activated)
            {
                activated = true;
                screamer.SetActive(true);
            }
        }
    }
}
