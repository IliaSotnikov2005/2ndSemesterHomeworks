using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.PostProcessing.HistogramMonitor;

public class ScreamerChance : MonoBehaviour
{
    public int screamerChanse;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
