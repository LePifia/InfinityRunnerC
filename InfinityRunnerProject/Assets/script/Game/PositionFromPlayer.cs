using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFromPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float distanceFromPlayer = 4;

    void Update()
    {
        if (player != null)
        {
            gameObject.transform.position = new Vector3(-2.5f, 0, player.transform.position.z - distanceFromPlayer);
        }
        
    }
}
