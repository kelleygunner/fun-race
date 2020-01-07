using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public static event System.Action<Vector3> OnCameraViewUpdate;
    public static event System.Action<Vector3> OnRespawnPointUpdated;
    public static event System.Action OnFinishReached;
    
    [SerializeField] private Vector3 _cameraView;
    [SerializeField] private Transform _respawnObject;
    [SerializeField] private bool isFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCameraViewUpdate?.Invoke(_cameraView);
            if(_respawnObject!=null)
                OnRespawnPointUpdated?.Invoke(_respawnObject.position);
            if (isFinish)
            {
                OnFinishReached?.Invoke();
            }
        }

        
    }
}
