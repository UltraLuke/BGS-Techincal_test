using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerModel _model;
    [SerializeField] private PlayerView _view;

    [SerializeField] float idleThreshold = 0.2f;
    
    private const float ZERO_THRESHOLD = 0.01f;

    private float _lastHInput = 0;
    private float _lastVInput = 0;
    private float _xAnim = 0;
    private float _yAnim = 0;
    
    private void FixedUpdate()
    {
        CheckAxes();
    }

    private void CheckAxes()
    {
        var hInput = Input.GetAxisRaw("Horizontal");
        var vInput = Input.GetAxisRaw("Vertical");

        Move(hInput, vInput);
        
        MoveAnimation(hInput, vInput, _lastHInput, _lastVInput);

        _lastHInput = hInput;
        _lastVInput = vInput;
    }

    private void Move(float h, float v)
    {
        _model.Move(h,v);
    }

    private void MoveAnimation(float h, float v, float lastH, float lastV)
    {
        if (Mathf.Abs(h) > ZERO_THRESHOLD)
        {
            if (Mathf.Abs(_yAnim) == idleThreshold)
                _yAnim = 0;
            
            _xAnim = h;
        }
        else if(lastH > ZERO_THRESHOLD)
            _xAnim = idleThreshold;
        else if (lastH < -ZERO_THRESHOLD)
            _xAnim = -idleThreshold;

        if (Mathf.Abs(v) > ZERO_THRESHOLD)
        {
            if (Mathf.Abs(_xAnim) == idleThreshold)
                _xAnim = 0;
            
            _yAnim = v;
        }
        else if(lastV > ZERO_THRESHOLD)
            _yAnim = idleThreshold;
        else if (lastV < -ZERO_THRESHOLD)
            _yAnim = -idleThreshold;
        
        _view.SetMovementAxes(_xAnim, _yAnim);
    }
}
