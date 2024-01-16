using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInstantiator : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] float playerDistance_Spawn_Level;

    [SerializeField] Transform[] levelArray;

    [SerializeField] GameObject player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = startPosition.transform.position;

    }

    private void Update()
    {
        if (Vector3.Distance (player.transform.position, lastEndPosition ) < playerDistance_Spawn_Level)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelArray[Random.Range(0, levelArray.Length)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);

        lastEndPosition = new Vector3 (lastLevelPartTransform.position.x, lastLevelPartTransform.position.y, lastLevelPartTransform.position.z - 15);
    }

    private Transform SpawnLevelPart(Transform LevelPart, Vector3 Position)
    {
        Transform LevelPartTransform = Instantiate(LevelPart, Position, Quaternion.identity);
        return LevelPartTransform;
    }
}
