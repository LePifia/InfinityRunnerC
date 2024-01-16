using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance { get; private set; }

    [SerializeField] GameObject obstacle1;
    [SerializeField] GameObject obstacle2;
    [SerializeField] GameObject coin;

    Transform player;

    [SerializeField] Transform[] positions;

    [SerializeField] float spawnRate;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        StartSpawning();
    }

    void SpawnFloorObstacle()
    {
        Transform randomTransform = positions[Random.Range(0, positions.Length)];

        Vector3 spawnPosition = new Vector3(randomTransform.position.x, obstacle1.transform.position.y, player.position.z - 15);

        Instantiate (obstacle1, spawnPosition, Quaternion.identity);
    }

    void SpawnRoofObstacle()
    {
        Transform randomTransform = positions[Random.Range(0, positions.Length)];

        Vector3 spawnPosition = new Vector3(randomTransform.position.x, obstacle2.transform.position.y, player.position.z - 15);

        Instantiate(obstacle2, spawnPosition, Quaternion.identity);
    }

    void SpawnCoin()
    {
        Transform randomTransform = positions[Random.Range(0, positions.Length)];

        Vector3 spawnPosition = new Vector3(randomTransform.position.x, coin.transform.position.y, player.position.z - 15);

        Instantiate(coin, spawnPosition, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnFloorObstacle", 5f, spawnRate);
        InvokeRepeating("SpawnRoofObstacle", 5f, spawnRate);
        InvokeRepeating("SpawnCoin", 1f, 1);
    }
}
