using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeDetection : MonoBehaviour
{
    private PlayerController controller;

    [SerializeField] float minimunDistance = 0.2f;
    [SerializeField] float swipeTime = 1.0f;

    [SerializeField] GameObject trail;

    private Vector2 startPos;
    private float startTime;

    private Vector2 endPos;
    private float endTime;

    [SerializeField, Range (0,1)] float directionTreshold = 0.9f;

    private Coroutine coroutine;

    [Header ("Events")]
    [SerializeField] UnityEvent swipeUp;
    [SerializeField] UnityEvent swipeDown;
    [SerializeField] UnityEvent swipeLeft;
    [SerializeField] UnityEvent swipeRight;




    private void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
    }


    private void OnEnable()
    {
        controller.OnStartTouch += SwipeStart;
        controller.OnEndTouch += SwipeEnd;

        trail.SetActive(false);
    }

    private void OnDisable()
    {
        controller.OnStartTouch -= SwipeStart;
        controller.OnEndTouch -= SwipeEnd;
    }


    private void SwipeStart(Vector2 pos, float time)
    {
        startPos = pos;
        startTime = time;

        trail.SetActive(true);
        trail.transform.position = pos;

        coroutine = StartCoroutine(Trail());
        
    }

    private void SwipeEnd(Vector2 pos, float time)
    {
        endPos = pos;
        endTime = time;

        trail.SetActive(false );
        StopCoroutine(coroutine);

        DetectSwipe();
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = controller.PrimaryPosition();

            yield return null;
        }
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPos, endPos) >= minimunDistance &&
            (endTime - startTime) <= swipeTime) {
        
            //Debug.DrawLine(startPos, endPos, Color.red,5f );
            //Debug.Log(startPos + " Swiping");
        
            Vector3 direction = startPos - endPos;
            Vector2 direction2D = new Vector2 (direction.x,direction.y).normalized;

            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionTreshold)
        {
            //Debug.Log("SwipeDown");
            swipeDown.Invoke();
        }

        if (Vector2.Dot(Vector2.down, direction) > directionTreshold)
        {
            //Debug.Log("SwipeUp");
            swipeUp.Invoke();
        }

        if (Vector2.Dot(Vector2.right, direction) > directionTreshold)
        {
            //Debug.Log("SwipeLeft");
            swipeLeft.Invoke();
        }

        if (Vector2.Dot(Vector2.left, direction) > directionTreshold)
        {
            //Debug.Log("swipeRight");
            swipeRight.Invoke();
        }
    }


}


