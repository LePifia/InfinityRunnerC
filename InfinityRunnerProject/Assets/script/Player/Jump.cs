using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] float jumpForce = 5;
    [SerializeField] float jumpDuration = 0.5f;

    bool jumping = true;
    [SerializeField] float timer = 0;

    [Header ("Events")]
    [SerializeField] UnityEvent jumpEvent;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
  
    }
    private void OnEnable()
    {
        //playerController.OnStartTouch += Jumping;
    }

    private void OnDisable()
    {
        //playerController.OnEndTouch -= Jumping;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                jumping = true;
            }
        }
    }
    public void Jumping()
    {
        if (jumping)
        {
            gameObject.transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), jumpForce, 1, jumpDuration);
            timer = 2;
            jumpEvent.Invoke();
            jumping = false;
            //Debug.Log("Jump");
        }
        
    }
}
