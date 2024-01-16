using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdInstaStart : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] UnityEvent OnAdStart;

    void Start()
    {
        OnAdStart.Invoke();
    }

}
