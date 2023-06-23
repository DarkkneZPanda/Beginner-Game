using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public List<Enemies> enemy = new List<Enemies>();
    public int currentWave;
    public float waveValue; 
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform EnemySpawn;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer <= 0) {
            //Spawn Enemy
            if(enemiesToSpawn.Count > 0) {
                Instantiate(enemiesToSpawn[0], EnemySpawn.position, Quaternion.identity); // First in List
                enemiesToSpawn.RemoveAt(0); // Remove 
                spawnTimer = spawnInterval;
            } else {
                waveTimer = 0; 
            }
        } else {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }
    public void GenerateWave() {
        waveValue = currentWave * 10;
        GenerateEnemies();
        spawnInterval = waveDuration / enemiesToSpawn.Count; // Fixed time for enemies
        waveTimer = waveDuration; // Wave duration 
    }

    public void GenerateEnemies() {
        // Creating a list to generate enemies
        // and repeat till we have no remaining currency
        List<GameObject>generatedEnemies = new List<GameObject>();
        while(waveValue > 0) {
            int randomEnemyId = Random.Range(0, enemy.Count);
            float randomEnemyCost = enemy[randomEnemyId].cost;
            // Check to see if can afford enemy
            // Add enemy to afford and deduct
            // Till we have no more points
            if(waveValue - randomEnemyCost >= 0) {
                generatedEnemies.Add(enemy[randomEnemyId].enemyPrefab);
                waveValue -= randomEnemyCost;
            } else if(waveValue <= 0) {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

}
[System.Serializable]
public class Enemies {
    public GameObject enemyPrefab;
    public float cost;
}
