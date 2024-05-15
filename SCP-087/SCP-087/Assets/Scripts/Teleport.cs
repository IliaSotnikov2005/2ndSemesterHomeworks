using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport target;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(pos.x, target.gameObject.transform.position.y, pos.z);
        }
    }
}