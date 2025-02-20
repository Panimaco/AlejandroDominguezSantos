using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //Zona de Variables Globales
    [SerializeField]
    private ParticleSystem _explosionShell;

    private AudioSource _audioSource;

    private Collider _coll;
    private Renderer _rend;

    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
        _coll = GetComponent<Collider>();
        _rend = GetComponent<Renderer>();

    }

    private void OnCollisionEnter(Collision infoCollision)
    {

        _coll.enabled = false;
        _rend.enabled = false;
        _explosionShell.Play();
        _audioSource.Play();
        Destroy(gameObject, 0.5f);

    }
}
