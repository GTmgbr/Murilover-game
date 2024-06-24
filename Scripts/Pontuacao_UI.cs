using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao_UI : MonoBehaviour
{
    TextMeshProUGUI textPontuacao;


    
    void Start()
    {
        textPontuacao = GetComponent<TextMeshProUGUI>();
    }

    public void AtualizaPontuacao(int pontuacao = 0)
    {
        textPontuacao.text = pontuacao.ToString();
    }
}
