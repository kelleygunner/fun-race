using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(5f, 100f)] private float _sensetive;
    
    private Transform _targetObject;
    private Vector3 _localPosition = Vector3.back*5;

    private void Awake()
    {
        EnterTrigger.OnCameraViewUpdate += OnCameraViewUpdate;
    }

    private void Update()
    {
        if (_targetObject != null)
        {
            transform.position = Vector3.Lerp(transform.position,_targetObject.position + _localPosition,
                Time.deltaTime * _sensetive);
            transform.LookAt(_targetObject);
        }
    }

    private void OnCameraViewUpdate(Vector3 viewPoint)
    {
        _localPosition = viewPoint;
    }

    private void OnDestroy()
    {
        EnterTrigger.OnCameraViewUpdate -= OnCameraViewUpdate;
    }

    public void UpdateCameraTarget(Transform targetObject)
    {
        _targetObject = targetObject;
    }
    
}
