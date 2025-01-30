using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JohnLemonMovement : MonoBehaviour
{
    //Zona de Variables Globales
    [Header("Movement")]
    [SerializeField]
    private float _speed,
                  _turnSpeed;

    //Direccion de movimiento
    [SerializeField]
    private Vector3 _direction;

    private Rigidbody _rb;
    private Animator _anim;
    private AudioSource _audioSource;
    private float _horizontal,
                  _vertical;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Rotation();
    }
    private void OnAnimatorMove()
    {
        _rb.MovePosition(transform.position + 
                        (_direction * _anim.deltaPosition.magnitude));
    }
    private void Update()
    {
        ImputsPlayer();
        IsAnimate();
        AudioSteps();
    }
    private void ImputsPlayer()
    {
        //Teclas A y D o Flechas Izquierda y Derecha
        _horizontal = Input.GetAxis("Horizontal");
        //Teclas W y S o Flechas Arriba y Abajo
        _vertical = Input.GetAxis("Vertical");

        _direction = new Vector3(_vertical, 0.0f, -_horizontal);
        //Normalizar
        _direction.Normalize();
    }
    private void IsAnimate()
    {
        if(_horizontal != 0 || _vertical != 0)
        {
            _anim.SetBool("IsWalking", true);
        }
        else
        {
            _anim.SetBool("IsWalking", false);
        }
    }
    private void Rotation()
    {
        Vector3 desiredFoward = Vector3.RotateTowards(
            transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);
        Quaternion rotation = Quaternion.LookRotation(desiredFoward);
        _rb.MoveRotation(rotation);
    }
    private void AudioSteps()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            if (!_audioSource.isPlaying) 
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
