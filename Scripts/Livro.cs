using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livro : MonoBehaviour
{
    
    public Vector2 spawnPosition;

    
    public Vector2 disappearPosition;

    public int velocidadeConstante;

    
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f) * velocidadeConstante;

        
        if (GetComponent<Rigidbody2D>().position.x <= disappearPosition.x)
        {
            Destroy(gameObject);
        }

    }
}
