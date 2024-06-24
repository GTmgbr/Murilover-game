using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vida_UI : MonoBehaviour
{
    TextMeshProUGUI textVida;

    
    void Start()
    {
        textVida = GetComponent<TextMeshProUGUI>();
    }

    public void AtualizaVida(int vida)
    {
        textVida.text = vida.ToString();
    }
}
