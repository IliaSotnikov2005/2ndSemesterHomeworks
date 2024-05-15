using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaiHider : MonoBehaviour
{
    [SerializeField] GameObject babay;
    [SerializeField] GameObject screamerTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            babay.SetActive(false);
            screamerTrigger.SetActive(false);
        }
    }
}
