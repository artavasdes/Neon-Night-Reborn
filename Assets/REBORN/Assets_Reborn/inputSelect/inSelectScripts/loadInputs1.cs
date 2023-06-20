using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class loadInputs1 : MonoBehaviour
{
    ReadOnlyArray<InputDevice> devices;
    // Start is called before the first frame update
    void Start()
    {
        devices = InputSystem.devices;
        foreach (var device in devices)
        {
            Debug.Log(device);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
