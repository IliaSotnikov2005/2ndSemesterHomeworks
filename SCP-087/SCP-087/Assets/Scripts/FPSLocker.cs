using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLocker : MonoBehaviour
{
    public int fpsLock;
    void Start()
    {
        Application.targetFrameRate = fpsLock;
    }
}
