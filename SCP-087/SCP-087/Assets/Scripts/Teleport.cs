using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport target;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 a = other.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(a.x, target.gameObject.transform.position.y, a.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = target.gameObject.transform.position;
        }
    }
}
