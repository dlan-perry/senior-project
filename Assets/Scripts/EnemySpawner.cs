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
    private GameObject player;
    private float randomized;

    // Start is called before the first frame update
    void Start()
    {
        randomized = Random.Range((float)(1), (float)(10));
        InvokeRepeating("SpawnNewEnemy", 6f, randomized);
    }

    private void SpawnNewEnemy()
    {
        player = GameObject.FindGameObjectWithTag("player");
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        randomXposition = playerX + Random.Range((float)(-5), (float)(5));
        randomYposition = playerY + Random.Range((float)(-5), (float)(5));
        
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
