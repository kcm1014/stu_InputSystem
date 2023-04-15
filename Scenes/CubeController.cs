using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]Vector3 _speed = Vector3.zero;
    Color _originalColor;
    Material _colorMat;
    // Start is called before the first frame update
    void Start()
    {
        _colorMat = GetComponent<Renderer>().material;
        _originalColor = _colorMat.color;
    }

    private void FixedUpdate() {
        transform.Translate(_speed * Time.deltaTime, Space.World);
    }

    public void ChangeCubeColor(Color? color = null){
        if(color == null)
            _colorMat.color = _originalColor;
        else
            _colorMat.color = (Color)color;
    }

    public void Move(Vector2 newSpeed){
        _speed.x = newSpeed.x;
        _speed.z = newSpeed.y;
    }
}
