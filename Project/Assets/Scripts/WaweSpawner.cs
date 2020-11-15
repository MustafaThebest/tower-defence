using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaweSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnLocation;
    public Text waveCountdownText;
    public float colddownTime = 2f;
    public int enemiesCountFactor = 3;
    private float countDown = 2f;
    private int waveIndex = 0;
    

    void Update()
    {
        if(countDown <= 0f)
        {
            if(!GameObject.Find("Enemy(Clone)"))
            {
                StartCoroutine(SpawnWave());
            }
            countDown = colddownTime;
        }
        countDown -= Time.deltaTime; 
        //waveCountdownText.text = Mathf.Round(countDown).ToString();
        waveCountdownText.text = $" WAVE {waveIndex.ToString()}";
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        int countEnemies = Random.Range(waveIndex, waveIndex + enemiesCountFactor);
        //print(countEnemies);
        for (int i = 0; i < countEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SpawnEnemy()
    {
         Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
