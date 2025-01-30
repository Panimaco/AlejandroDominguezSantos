using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Zona de Variables Globales
    [Header("Iamges")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;

    [Header("Fade")]
    //Duracion del fade de la imagen que va a apraecer poco a poco
    [SerializeField]
    private float _fadeDuration;
    //Total del tiempo que va a durar la imagen en pantalla
    [SerializeField]
    private float _displayImageDuration;
    //Contador de tiempo
    private float _timer;
    //Si el jugador salio del nivel
    public bool IsPlayerAsExit;
    //Si el jugador fue atrapado
    public bool IsPlayerCaught;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _wonImage.gameObject.SetActive(false);
        _caughtImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (IsPlayerAsExit)
        {
            Won();
        }
        else if (IsPlayerCaught)
        {
            Caught();
        }
    }

    private void Won()
    {
        _wonImage.gameObject.SetActive(true);
        _audioSource.clip = _wonClip;
        if(!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        _timer = _timer + Time.deltaTime;

        //Aumentar el canal alfa de la imagen poco a poco
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g,
                                    _wonImage.color.b, _timer / _fadeDuration);

        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("He ganado");
        }
    }

    private void Caught()
    {
        _caughtImage.gameObject.SetActive(true);
        _audioSource.clip = _caughtClip;
        
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        _timer = _timer + Time.deltaTime;

        //Aumentar el canal alfa de la imagen poco a poco
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g,
                                       _caughtImage.color.b, _timer / _fadeDuration);

        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("He perdido");
            SceneManager.LoadScene("JuanitoLimones");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("JuanitoLimones");
    }

    private void OnTriggerEnter(Collider infoCollider)
    {
        if (infoCollider.CompareTag("JohnLemon"))
        {
            IsPlayerAsExit = true;
        }
    }
}
