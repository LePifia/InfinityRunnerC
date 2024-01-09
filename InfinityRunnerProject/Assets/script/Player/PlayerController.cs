using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class PlayerController : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    

    private InputMap inputmap;

    private CharacterController controller;
    private Vector3 direction;
    [SerializeField] float forwardSpeed;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputmap = new InputMap();
        
    }

    private void OnEnable()
    {
        inputmap.Enable();
        TouchSimulation.Enable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        inputmap.Disable();
        TouchSimulation.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void Start()
    {
        inputmap.Mobile.TouchPress.started += ctx => StartTouch(ctx);
        inputmap.Mobile.TouchPress.canceled += ctx => EndTouch(ctx);

        
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("TouchStarted" + inputmap.Mobile.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(inputmap.Mobile.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("TouchEnded");
        if (OnEndTouch != null) OnEndTouch(inputmap.Mobile.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }

    private void FingerDown(Finger finger)
    {

    }


    private void Update()
    {
        direction.z = forwardSpeed;

    }

    private void FixedUpdate()
    {
        //controller.Move(direction * Time.fixedDeltaTime);
    }

 
}
