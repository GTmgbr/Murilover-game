using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private GameObject canvas;


    public void ReiniciarJuego()
    {

        DestruirObjetosPersistidos();
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void DestruirObjetosPersistidos()
    {
        
        player = GameObject.FindWithTag("Player");
        canvas = GameObject.FindWithTag("Canvas");

       
        if (player != null)
            Destroy(player);

        if (canvas != null)
            Destroy(canvas);

    }
}
