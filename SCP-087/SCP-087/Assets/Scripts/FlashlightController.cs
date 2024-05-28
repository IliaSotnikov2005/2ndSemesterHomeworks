// <copyright file="FlashlightController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// Controller for the flashlight.
/// </summary>
public class FlashlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject spotlight;

    private bool isFlashlightOn = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.isFlashlightOn = !this.isFlashlightOn;

            if (this.isFlashlightOn)
            {
                this.spotlight.SetActive(true);
            }
            else
            {
                this.spotlight.SetActive(false);
            }
        }
    }
}
