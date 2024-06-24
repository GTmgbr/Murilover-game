using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menuAudio;

    public void VoltaMenuPrincipal()
    {
        menuAudio.SetActive(false);
    }
}
