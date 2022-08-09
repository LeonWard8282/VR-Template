using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerInputScript : MonoBehaviour
{

    [Header("Right Controller ButtonSource")]
    public XRNode right_HandButtonSource;

    [Header("Left Controller ButtonSource")]
    public XRNode left_HandButtonSource;

    [SerializeField] private bool primaryButtonPressed;

    [Header("Visual Right Hand Buttons Bool Check")]
    [Tooltip("Do not edit, just a visual refference to see that the button is pressed")]
    [SerializeField] private bool rightAButtonPressed;
    [SerializeField] private bool right_B_ButtonPressed;
    [SerializeField] private bool right_2DAxisClicked;
    [SerializeField] private bool right_2DAxisTouched;

    [Header("Visual Left Hand Buttons Bool Check")]
    [Tooltip("Do not edit, just a visual refference to see that the button is pressed")]

    [SerializeField] private bool left_X_ButtonPressed;
    [SerializeField] private bool left_Y_ButtonPressed;
    [SerializeField] private bool left_2DAxisClicked;
    [SerializeField] private bool left_2DAxisTouched;
    [SerializeField] private bool left_MenueButtonTouched;


    [Header("Right Hand Button Events")]
    [SerializeField] private UnityEvent aButtonPressed;
    [SerializeField] private UnityEvent bButtonPressed;
    [SerializeField] private UnityEvent right_2DAxis_Click;
    [SerializeField] private UnityEvent right_2DAxisTouch;

    [Header("Left Hand Button Events")]
    [SerializeField] private UnityEvent xButtonPressed;
    [SerializeField] private UnityEvent yButtonPressed;
    [SerializeField] private UnityEvent left_2DAxis_Click;
    [SerializeField] private UnityEvent left_2DAxisTouch;
    [SerializeField] private UnityEvent left_MenuePressed;


    private CharacterController character; // this character controller will manage how we move the rig when we collide with an object

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RightHandInputDevice();
        LeftHandInputDevice();

        InvokingRightHandEvents();
        InvokingLeftHandEvents();
    }

    private void LeftHandInputDevice()
    {
        InputDevice XButton = InputDevices.GetDeviceAtXRNode(left_HandButtonSource);
        XButton.TryGetFeatureValue(CommonUsages.primaryButton, out left_X_ButtonPressed);

        InputDevice YButton = InputDevices.GetDeviceAtXRNode(left_HandButtonSource);
        YButton.TryGetFeatureValue(CommonUsages.secondaryButton, out left_Y_ButtonPressed);

        InputDevice left_2DAxisClick = InputDevices.GetDeviceAtXRNode(left_HandButtonSource);
        left_2DAxisClick.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out left_2DAxisClicked);

        InputDevice left_2DAxisTouch = InputDevices.GetDeviceAtXRNode(left_HandButtonSource);
        left_2DAxisTouch.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out left_2DAxisTouched);


        InputDevice left_MenueTouch = InputDevices.GetDeviceAtXRNode(left_HandButtonSource);
        left_MenueTouch.TryGetFeatureValue(CommonUsages.menuButton, out left_MenueButtonTouched);
    }

    private void RightHandInputDevice()
    {
        // RIGHT HAND
        InputDevice AButton = InputDevices.GetDeviceAtXRNode(right_HandButtonSource);
        AButton.TryGetFeatureValue(CommonUsages.primaryButton, out rightAButtonPressed);

        InputDevice BButton = InputDevices.GetDeviceAtXRNode(right_HandButtonSource);
        BButton.TryGetFeatureValue(CommonUsages.secondaryButton, out right_B_ButtonPressed);

        InputDevice right_2DAxisClick = InputDevices.GetDeviceAtXRNode(right_HandButtonSource);
        right_2DAxisClick.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out right_2DAxisClicked);

        InputDevice right_2DAxisTouch = InputDevices.GetDeviceAtXRNode(right_HandButtonSource);
        right_2DAxisTouch.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out right_2DAxisTouched);
    }


    private void InvokingLeftHandEvents()
    {
        if (left_X_ButtonPressed == true)
        {
            xButtonPressed.Invoke();
        }

        if (left_Y_ButtonPressed == true)
        {
            yButtonPressed.Invoke();
        }

        if (left_2DAxisClicked == true)
        {
            left_2DAxis_Click.Invoke();
        }

        if (left_2DAxisTouched == true)
        {
            left_2DAxisTouch.Invoke();
        }

        if (left_MenueButtonTouched == true)
        {
            left_MenuePressed.Invoke();
        }
    }

    private void InvokingRightHandEvents()
    {
        if (rightAButtonPressed == true)
        {
            aButtonPressed.Invoke();
        }

        if (right_B_ButtonPressed == true)
        {
            bButtonPressed.Invoke();
        }

        if (right_2DAxisClicked == true)
        {
            Debug.Log("This event is being runed");
            right_2DAxis_Click.Invoke();
        }

        if (right_2DAxisTouched == true)
        {
            right_2DAxisTouch.Invoke();
        }
    }
}
