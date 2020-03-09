using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float timer;
    private float maxTimer;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = Random.Range(5f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpawnEnemyTimer");
    }

    void SpawnEnemy()
    {
        float y = 1.25f;
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), y, 0));
        spawnPoint.z = 0;
        GameObject.Instantiate(enemy, spawnPoint, new Quaternion(0, 0, 0, 0));
    }

    IEnumerator SpawnEnemyTimer()
    {
        if(timer >= maxTimer)
        {
            //spawn an enemy
            SpawnEnemy();
            timer = 0;
            maxTimer = Random.Range(5f, 12f);

        }

        timer += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
}
