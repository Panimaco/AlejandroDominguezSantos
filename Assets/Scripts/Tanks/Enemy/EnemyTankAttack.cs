using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankAttack : MonoBehaviour
{

    //Zona de Variables Globales
    [Header("Variables de Ataque")]
    [SerializeField]
    private float _timeBetweenShots;
    [SerializeField]
    private Rigidbody _shellPrefab;
    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;

    private float _timer;
    private bool _isAttack;

    public bool IsCloseToPlayer;

    [Header("Variables de Sonido")]
    [SerializeField]
    private AudioSource _audioSource;

    [Header("Raycast")]
    private Ray _ray;
    private RaycastHit _hit;
    private float _distanceToPlayer;
    [SerializeField]
    private float _launchForceFactor;

    private void Awake()
    {
        _isAttack = false;
    }

    private void FixedUpdate()
    {
        if (_isAttack)
        {
            Fire();
            _isAttack = false;
        }
    }

    void Update()
    {
        CountTimer();        
    }

    private void CountTimer()
    {

        //Origen del rayo
        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        //Empieza el contador
        _timer += Time.deltaTime;

        //Si el rayo choca con el jugador
        if (Physics.Raycast(_ray, out _hit))
        {

            //Si el contador es mayor o igual al tiempo entre disparos
            if (
                _hit.collider.CompareTag("PlayerTank") &&
                _timer >= _timeBetweenShots)

            {

                //Resetea el contador
                _timer = 0;

                _isAttack = true;

                //Distancia al jugador
                _distanceToPlayer = _hit.distance;

            }
        }
    }

    private void Fire()
    {

        float launchForceFinal = _launchForce * _distanceToPlayer * _launchForceFactor;

        Rigidbody shell = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        _audioSource.Play();

        shell.velocity = launchForceFinal * _posShell.forward;

    }
}
