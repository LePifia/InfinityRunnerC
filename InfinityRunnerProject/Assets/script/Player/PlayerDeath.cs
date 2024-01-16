using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    GameObject player;
    

    [SerializeField] GameObject deadPosition;

    [Header("Events")]
    [SerializeField] UnityEvent OnPlayerDead;

     private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
    }

    private void Update()
    {

        if (player.transform.position.y < deadPosition.transform.position.y)
        {
            PlayerDead();
        }
    }

    public void PlayerDead()
    {
        OnPlayerDead.Invoke();
        Debug.Log("Dead");
    }
}
