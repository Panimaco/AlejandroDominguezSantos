using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //Zona de Variables Globales
    //Referencia al Prefabricado de la bala
    [SerializeField]
    private Rigidbody _shellPrefab;
    //Referencia al punto de disparo
    [SerializeField]
    private Transform _posShell;
    //Fuerza de disparo
    [SerializeField]
    private float _launchForce;
    //Referencia al audio de disparo
    [SerializeField]
    private AudioSource _audioSource;

    // Update is called once per frame
    void Update()
    {

        InputPlayer();

    }

    private void InputPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {

        Rigidbody shell = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        _audioSource.Play();

        shell.velocity = _launchForce * _posShell.forward;

    }
}