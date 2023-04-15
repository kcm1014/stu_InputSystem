using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManagerWithClass : MonoBehaviour
{
    PlayerInputActions _input;
    // Start is called before the first frame update
    void Awake() {
        _input = new PlayerInputActions();

        _input.Player.AbilityX.performed += OnAbilityX;
        _input.Player.AbilityX.canceled += OnAbilityX;
        
        _input.Player.AbilityZ.performed += OnAbilityZ;
        _input.Player.AbilityZ.canceled += OnAbilityZ;

    }

    private void OnEnable() {
        _input.Enable();
    }

    private void OnDisable() {
        _input.Disable();
    }

    private void OnDestroy() {
        _input.Dispose();
    }

    private void OnAbilityZ(InputAction.CallbackContext obj)
    {
        Debug.Log("Ability Z :" + obj.phase);
        Debug.Log(obj.ReadValueAsButton());
        if(obj.performed)
            GetComponent<CubeController>().ChangeCubeColor(Color.green);
        else
            GetComponent<CubeController>().ChangeCubeColor();
    }

    private void OnAbilityX(InputAction.CallbackContext obj)
    {
        Debug.Log("Ability x :" + obj.phase); // 단계 performed, canceled
        Debug.Log(obj.ReadValueAsButton());   // true, false
        if(obj.performed)
            GetComponent<CubeController>().ChangeCubeColor(Color.red);
        else
            GetComponent<CubeController>().ChangeCubeColor();
    }

    // Update is called once per frame
    void Update()
    {
        //최초 눌릴때 발생
        if(_input.Player.AbilityX.WasPressedThisFrame())
            Debug.Log("Pressed key now!");

        //눌린 동안 계속 발생
        if(_input.Player.AbilityX.IsPressed())
            Debug.Log("Being Pressed!");
    }
}
