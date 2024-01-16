using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    private void Start()
    {
        Invoke("DisableObject", 25f);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
