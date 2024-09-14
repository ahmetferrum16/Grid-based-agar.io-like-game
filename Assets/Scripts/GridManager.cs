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
            isSpawned= false;
        }
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < width ; i++){
            for (int j = 0; j < height; j++){
                var spawnedFile = Instantiate(tile, new Vector2(i, j),Quaternion.identity);


            }
        }
        
    }
    public static Vector3 randomPos()
    {
        int Xaxis = Random.Range(0, 15);
        int Yaxis = Random.Range(0, 9);

        return new Vector3(Xaxis, Yaxis, 0);
    }

    public void spawnEnemy()
    {
        if (rndEnemySpawn == 1)
            Instantiate(lowHP, randomPos(), Quaternion.identity);
            
        else if (rndEnemySpawn == 2)
        {
            Instantiate(highHP, randomPos(), Quaternion.identity);
        }
        rndEnemySpawn = Random.Range(1, 3);
    }

}
