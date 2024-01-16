using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] playerScripts;

    [Header("Events")]
    [SerializeField] UnityEvent DisabledFromMoving;

    public void OnPlayerDead()
    {
        foreach (MonoBehaviour playerScript in playerScripts)
        {
            playerScript.enabled = false;
            DisabledFromMoving.Invoke();
        }
    }
}
