using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    MainMenu menu;
    GameManager gameManager;

    private void Awake()
    {
        menu = GetComponent<MainMenu>();
        gameManager = GetComponent<GameManager>();
    }


    private void Start()
    {
        Invoke("DisableObject", 25f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerDeath>().PlayerDead();
            DisableObject();
        }

    }

    void DisableObject()
    {
       gameObject.SetActive(false);
    }
}
