using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerButtonPress : MonoBehaviour
{
    public InputActionReference rightPrimaryButtonReffernce;
     XRIDefaultInputActions rightButtonPress;

    private void Awake()
    {
        rightPrimaryButtonReffernce.action.started += rightPrimaryButtonPress;
    }

    private void OnDestroy()
    {
        rightPrimaryButtonReffernce.action.started -= rightPrimaryButtonPress;
    }
    private void OnEnable()
    {
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void rightPrimaryButtonPress(InputAction.CallbackContext context)
    {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }

}
