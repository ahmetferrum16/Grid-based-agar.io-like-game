using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
public class GridManager : MonoBehaviour
{
    public int width, height;
    public GameObject tile;
    public GameObject lowHP;
    public GameObject highHP;
    private bool isSpawned = false;
    public int spawnFreq;
    public int targetCount;
    public int rndEnemySpawn;

    public Transform playerTransform; // Player'ý inspector'dan baðla

    void Start()
    {
        targetCount = 4;
        GenerateGrid();
        rndEnemySpawn = Random.Range(1, 3);
    }

    void Update()
    {
        if (GridMovement.MoveCount == targetCount && !isSpawned)
        {
            spawnEnemy();
            GridMovement.MoveCount++;
            isSpawned = true;
            targetCount += Random.Range(3, 6);
        }
        else
        {
            isSpawned = false;
        }
    }
    public void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var spawnedFile = Instantiate(tile, new Vector2(i, j), Quaternion.identity);
            }
        }

    }

    // Oyuncudan en az minDistance uzakta, grid içinde rastgele pozisyon üretir
    public Vector3 randomPosAwayFromPlayer(float minDistance = 4f)
    {
        Vector3 spawnPos;
        int attempts = 0;
        do
        {
            int Xaxis = Random.Range(1, 14); // Kenarlardan 1 tile içeride
            int Yaxis = Random.Range(1, 8);
            spawnPos = new Vector3(Xaxis, Yaxis, 0);
            attempts++;
            if (attempts > 50) break; // Sonsuz döngü önlemi
        }
        while (playerTransform != null && Vector3.Distance(spawnPos, playerTransform.position) < minDistance);

        return spawnPos;
    }

    public void spawnEnemy()
    {
        Vector3 pos = randomPosAwayFromPlayer();

        if (rndEnemySpawn == 1)
            Instantiate(lowHP, pos, Quaternion.identity);

        else if (rndEnemySpawn == 2)
        {
            Instantiate(highHP, pos, Quaternion.identity);
        }
        rndEnemySpawn = Random.Range(1, 3);
    }
}