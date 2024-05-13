using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaiOccurence : MonoBehaviour
{
    [SerializeField] private GameObject babai;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Random.Range(1, 11) == 1)
            {
                babai.SetActive(true);
            }
        }
    }
}
