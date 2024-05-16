using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private GameObject spotlight;

    private bool isFlashlightOn = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;

            if (isFlashlightOn)
            {
                spotlight.SetActive(true);
            }
            else
            {
                spotlight.SetActive(false);
            }
        }
    }
}
