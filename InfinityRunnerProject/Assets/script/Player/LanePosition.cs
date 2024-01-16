using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class LanePosition : MonoBehaviour
{
    private PlayerController playerController;

    private Vector3 direction;
    [SerializeField] float forwardSpeed;

    [SerializeField] GameObject PlayerModel;

    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    [SerializeField] Transform position3;

    float frameInterval = 15;

    float timer = 0;

    private Transform selectedPosition;

    private Camera cameraMain;
    bool changingLanes = true;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        cameraMain = Camera.main;
        selectedPosition = position2;
    }

    private void OnEnable()
    {
        playerController.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        playerController.OnEndTouch -= Move;
    }

    private void Update()
    {
        direction = transform.forward;
        transform.position += forwardSpeed * Time.deltaTime * direction;

        if (Time.frameCount / frameInterval == 0)
        {
            PlayerModel.transform.DOLookAt(selectedPosition.position, 0.5f, AxisConstraint.None);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0;

                if (changingLanes == false)
                {
                    changingLanes = true;
                }
                
            }
        }
        
    }

    private void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, transform.position.z);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);

        worldCoordinates.z = transform.position.z;
        worldCoordinates.y = transform.position.y;

        if (changingLanes)
        {
            if (worldCoordinates.x <= position1.transform.position.x)
            {
                gameObject.transform.DOLocalMoveX(position3.position.x, 2f);
                selectedPosition = position3;

                changingLanes = false;

                timer = 0.5f;
                //Debug.Log("position3");
            }

            if (worldCoordinates.x >= position1.transform.position.x && worldCoordinates.x <= position3.transform.position.x)
            {
                gameObject.transform.DOLocalMoveX(position2.position.x, 2f);
                selectedPosition = position2;

                changingLanes = false;
                //Debug.Log("position2");

                timer = 0.5f;

            }

            if (worldCoordinates.x >= position3.transform.position.x)
            {
                gameObject.transform.DOLocalMoveX(position1.position.x, 2f);
                selectedPosition = position1;

                changingLanes = false;

                timer = 0.5f;
                //Debug.Log("position1");
            }
        }
    }
}
