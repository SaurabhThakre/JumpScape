using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject[] fruitPrefabs;
    public GameObject spikePrefab;
    public GameObject[] enemyPrefabs;

    public Vector3 spawnPosition;

    private int platformCount = 150;
    public float levelWidth = 6;
    public float minY = 2;
    public float maxY = 4;
    public float fruitXRange = 1.5f;
    public float fruitMinY = 3;
    public float fruitMaxY = 6;
    public float spikeXRange = 1.4f;
    private float spikeY = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3();
        spawnPosition.x = 0;
        spawnPosition.y = -3;

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            spawnPosition.z = this.transform.position.z;
            GameObject obj = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
            generateFruits(spawnPosition);
            generateSpikes(spawnPosition);
            generateEnemys(spawnPosition, obj);
        }
    }

    void generateFruits(Vector3 platformPos)
    {
        Vector3 fruitSpawnPosition = new Vector3();
        int fruitIndex;

        if (Random.Range(0, 2) == 1)
        {
            fruitSpawnPosition.y = platformPos.y + Random.Range(fruitMinY, fruitMaxY);
            fruitSpawnPosition.x = platformPos.x + Random.Range(-fruitXRange, fruitXRange);
            fruitSpawnPosition.z = platformPos.z - 2;
            fruitIndex = Random.Range(0, fruitPrefabs.Length);
            GameObject fruitObj = Instantiate(fruitPrefabs[fruitIndex], fruitSpawnPosition, Quaternion.identity);
            fruitObj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    void generateSpikes(Vector3 platformPos)
    {
        Vector3 spikeSpawnPosition = new Vector3();

        if (Random.Range(0, 5) == 1)
        {
            spikeSpawnPosition.y = platformPos.y + spikeY;
            spikeSpawnPosition.x = platformPos.x + Random.Range(-spikeXRange, spikeXRange);
            spikeSpawnPosition.z = platformPos.z - 1;
            GameObject spikeObj = Instantiate(spikePrefab, spikeSpawnPosition, Quaternion.identity);
            spikeObj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    void generateEnemys(Vector3 platformPos, GameObject obj)
    {
        Vector3 enemySpawnPosition = new Vector3();
        int enemyIndex;

        if (Random.Range(0, 10) == 1)
        {
            enemySpawnPosition.y = platformPos.y + spikeY + 0.1f;
            enemySpawnPosition.x = platformPos.x + Random.Range(-spikeXRange+1, spikeXRange-1);
            enemySpawnPosition.z = platformPos.z - 1;
            enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyObj = Instantiate(enemyPrefabs[enemyIndex], enemySpawnPosition, Quaternion.identity);
            enemyObj.transform.SetParent(obj.transform); // set as children of Spawn Manager
        }
    }

}
