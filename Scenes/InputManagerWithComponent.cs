using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManagerWithComponent : MonoBehaviour
{
    PlayerInput _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();

        _input.actions["AbilityZ"].performed += OnAbilityZ;
        _input.actions["AbilityZ"].canceled += OnAbilityZ;

        _input.actions["AbilityX"].performed += OnAbilityX;
        _input.actions["AbilityX"].canceled += OnAbilityX;

        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    Behavior : Send Message 형태
    public void OnAbilityX(InputValue value){
        //ActionType : Value 인경우 눌리는 순간(True), 떨어질때(False) 값 체크
        Debug.Log("Ability X!");
        Debug.Log(value.isPressed);
    }

    public void OnAbilityZ(InputValue value){
        // ActionType : Button 인경우 눌리는 순간(True)값만 체크
        Debug.Log("Ability Z!");
        Debug.Log(value.isPressed);
    }
    */

    /*
    Behavior : Invoke Unity Events
    이벤트 연결을 해주어야 함.
    Behavior : Invoke C Shap Events
    위쪽에서 
    PlayerInput _input; 해서 모든 이벤트를 등록해주어야 함.
    */
    public void OnAbilityZ(InputAction.CallbackContext context){
        Debug.Log("Ability Z!");
        Debug.Log(context.ReadValueAsButton());

        if(context.performed)
            GetComponent<CubeController>().ChangeCubeColor(Color.green);
        else
             GetComponent<CubeController>().ChangeCubeColor();
    }

    public void OnAbilityX(InputAction.CallbackContext context){
        Debug.Log("Ability X!");
        Debug.Log(context.ReadValueAsButton());

        if(context.performed)
            GetComponent<CubeController>().ChangeCubeColor(Color.red);
        else
             GetComponent<CubeController>().ChangeCubeColor();
    }

    public void OnMove(InputAction.CallbackContext context){
        Debug.Log(context.ReadValue<Vector2>());
        GetComponent<CubeController>().Move(context.ReadValue<Vector2>());
    }
    
}
