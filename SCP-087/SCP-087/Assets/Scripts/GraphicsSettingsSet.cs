using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSettingsSet : MonoBehaviour
{
    [SerializeField] private int fpsLock = -1;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fpsLock;
    }
}
