using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{

    [SerializeField] GameObject menuAudio;


    public void CarregaScene(string fase)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void abreMenu()
    {
        menuAudio.SetActive(true);
    }
}
