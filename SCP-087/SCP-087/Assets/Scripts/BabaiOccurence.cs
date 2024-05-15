using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaiOccurence : MonoBehaviour
{
    [SerializeField] private GameObject babai;
    [SerializeField] private GameObject babaiTrigger;

    public int babaiOccurencePercent;

    private bool activated = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Random.Range(1, 101) <= babaiOccurencePercent || activated)
            {
                activated = true;
                babai.SetActive(true);
                babaiTrigger.SetActive(true);
            }
        }
    }
}
