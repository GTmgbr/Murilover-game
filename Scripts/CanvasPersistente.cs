using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPersistente : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
