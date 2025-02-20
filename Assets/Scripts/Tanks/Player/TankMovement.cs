using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    //Zona de Variables Globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    private float _horizontal,
                  _vertical;
    private Rigidbody _rb;

    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivingClip;

    private AudioSource _audioSource;

    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {

        Movement();
        Turn();

    }

    // Update is called once per frame
    void Update()
    {

        InputsPlayer();
        AudioPlayer();

    }

    private void InputsPlayer()
    {

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    
    }

    private void Movement()
    {

        Vector3 movement = transform.forward * _vertical * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + movement);
    
    }

    private void Turn()
    {

        if (_vertical < 0.0f)
        {
            _horizontal = -_horizontal;
        }

        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);
        _rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {

        //Si hay algun tipo de movimiento
        if (_horizontal != 0.0f || _vertical != 0.0f)
        {
            //Si no se esta reproduciendo el clip de movimiento
            if (_audioSource.clip != _drivingClip)
            {
                _audioSource.clip = _drivingClip;
                _audioSource.Play();
            }
        }

        //Si no hay movimiento
        else
        {
            //Si no se esta reproduciendo el clip de idle
            if (_audioSource.clip != _idleClip)
            {
                _audioSource.clip = _idleClip;
                _audioSource.Play();
            }
        }
    }
}
