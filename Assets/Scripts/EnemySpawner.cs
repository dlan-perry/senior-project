using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 7f);
    }

    private void SpawnNewEnemy()
    {
        randomXposition = Random.Range((float)(-8.5), (float)(7.5));
        randomYposition = Random.Range((float)(-3.5), (float)(9));
        
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
        rend.color = new Color(Random.Range(0,2), Random.Range(0,2), Random.Range(0,2), 1f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
