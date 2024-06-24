using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject obstaculo1Prefab;
    public GameObject vidaPrefab;
    public GameObject dinheiroPrefab;
    public GameObject indestrutivelPrefab;
    public GameObject obstaculo2Prefab;
    public Vector2 spawnPosition;
    public float spawnIntervalObstaculo1;
    public float spawnIntervalVida;
    public float spawnIntervalDinheiro;
    public float spawnIntervalIndestrutivel;
    public float spawnIntervalObstaculo2;
    public int maxObstaculo1;
    public int maxDinheiro;
    public int maxObstaculo2;

    private float spawnTimerObstaculo1;
    private float spawnTimerVida;
    private float spawnTimerDinheiro;
    private float spawnTimerIndestrutivel;
    private float spawnTimerObstaculo2;

    void Update()
    {
        
        if (spawnTimerObstaculo1 >= spawnIntervalObstaculo1)
        {
            SpawnObject(obstaculo1Prefab, spawnPosition, maxObstaculo1, -3f, 4f);


            spawnTimerObstaculo1 = 0;
        }
        if (spawnTimerDinheiro >= spawnIntervalDinheiro)
        {
            SpawnObject(dinheiroPrefab, spawnPosition, maxDinheiro, -3f, 4f);

            
            spawnTimerDinheiro = 0;
        }
        if (spawnTimerVida >= spawnIntervalVida)
        {
            SpawnObject(vidaPrefab, spawnPosition, 1, -3f, 4f);

            
            spawnTimerVida = 0;
        }
        if (spawnTimerIndestrutivel >= spawnIntervalIndestrutivel)
        {
            SpawnObject(indestrutivelPrefab, spawnPosition, 1, -3f, 4f);


            spawnTimerIndestrutivel = 0;
        }
        if (spawnTimerObstaculo2 >= spawnIntervalObstaculo2)
        {
            SpawnObject(obstaculo2Prefab, spawnPosition, 1, -3.30f, -3.30f);


            spawnTimerObstaculo2 = 0;
        }

        spawnTimerObstaculo1 += Time.deltaTime;
        spawnTimerDinheiro += Time.deltaTime;
        spawnTimerVida += Time.deltaTime;
        spawnTimerIndestrutivel += Time.deltaTime;
        spawnTimerObstaculo2 += Time.deltaTime;
    }

    void SpawnObject(GameObject prefab, Vector2 spawnPos, int maxCount, float yMin, float yMax)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(prefab.tag);

        
        int numObjects = objects.Length;

        
        if (numObjects < maxCount)
        {
            Instantiate(prefab, new Vector2(spawnPos.x, Random.Range(yMin, yMax)), Quaternion.identity);

        }
    }
}

