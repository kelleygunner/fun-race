using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IControl
{
    public event Action OnStart;
    public event Action OnStop;

    private bool _isTouched = false;

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            OnStart?.Invoke();
        if (Input.GetMouseButtonUp(0))
            OnStop?.Invoke();
        return;
        #endif
        if (Input.touches.Length > 0)
        {
            if (!_isTouched)
            {
                _isTouched = true;
                OnStart?.Invoke();
            }
        }
        else
        {
            if (_isTouched)
            {
                _isTouched = false;
                OnStop?.Invoke();
            }
        }
    }
}
