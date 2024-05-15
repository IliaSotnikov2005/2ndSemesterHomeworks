using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerOccurence : MonoBehaviour
{
    [SerializeField] private GameObject screamer;

    private bool activated = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Random.Range(1, 101) <= GlobalReferences.ScreamerChanse || activated)
            {
                activated = true;
                screamer.SetActive(true);
            }
        }
    }
}
