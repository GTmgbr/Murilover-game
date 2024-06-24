using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float scrollSpeed = -2.5f;
    public float resetDistance = 10.0f;
    public float inicialPosition = 0;

    void Update()
    {
        float currentX = transform.position.x;
        float newOffset = currentX + scrollSpeed * Time.deltaTime;

        
        transform.position = new Vector2(newOffset, transform.position.y);

        
        if (currentX <= resetDistance)
        {
            
            Vector2 newPosition = new Vector2(currentX + inicialPosition, transform.position.y);
            transform.position = newPosition;
        }
    }
}
