using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanePosition : MonoBehaviour
{
    private PlayerController playerController;
    private int desiredLane = 2; // 1:Left 2:Middle 3:right
    [SerializeField] float laneDistance = 2;

    private Camera cameraMain;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        playerController.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        playerController.OnEndTouch -= Move;
    }

    private void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, transform.position.z);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);

        worldCoordinates.z = transform.position.z;
        worldCoordinates.y = transform.position.y;

        transform.position = worldCoordinates;  
        Debug.Log(transform.position);
    }

}
