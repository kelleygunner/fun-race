using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _controlObject;
    [SerializeField] private float _sidePosition;
    [SerializeField] private float _speedMax;

    [SerializeField] private ParticleSystem _parts;
    
    private IControl _control;

    private float speed = 0;

    private Vector3 _playerPos;

    private bool _isControled = false;

    private Vector3 _respawnPoint;
    private Quaternion _defaultRotation;

    private RigidbodyConstraints _constraints;

    public bool IsControled
    {
        get => _isControled;
        set => _isControled = value;
    }

    void Start()
    {
        _constraints = _rigidbody.constraints;
        _defaultRotation = transform.rotation;
            
        _control = _controlObject.GetComponent<IControl>();
        _control.OnStart += StartMovement;
        _control.OnStop += StopMovement;
        EnterTrigger.OnRespawnPointUpdated += UpdateRespawnPoint;
        EnterTrigger.OnFinishReached += OnFinishReached;
    }

    private void OnFinishReached()
    {
        _isControled = false;
    }

    private void UpdateRespawnPoint(Vector3 point)
    {
        _respawnPoint = point;
    }

    private void StopMovement()
    {
        speed = 0;
    }

    private void StartMovement()
    {
        speed = _speedMax;
    }

    private void Update()
    {
        if (_isControled)
        {
            _rigidbody.velocity = Vector3.forward * speed;
        }
        
    }

    private void OnDestroy()
    {
        _control.OnStart -= StartMovement;
        _control.OnStop -= StopMovement;
        EnterTrigger.OnRespawnPointUpdated -= UpdateRespawnPoint;
        EnterTrigger.OnFinishReached -= OnFinishReached;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle") && _isControled)
        {
            StartCoroutine(RespawnPlayer(other.impulse));
            _parts.transform.position = other.contacts[0].point;
            _parts.Emit(30);
        }
    }

    IEnumerator RespawnPlayer(Vector3 impulse)
    {
        speed = 0;
        _isControled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.AddForce(
            new Vector3(Random.Range(-10f,10f),Random.Range(30f,50f),Random.Range(-10f,10f))
            + impulse * 30f);
        yield return new WaitForSeconds(1);
        _respawnPoint.x = _sidePosition;
        transform.position = _respawnPoint;
        _isControled = true;
        _rigidbody.constraints = _constraints;
        transform.rotation = _defaultRotation;
    }
}
