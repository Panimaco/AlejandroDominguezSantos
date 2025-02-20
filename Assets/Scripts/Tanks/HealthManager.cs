using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //Zona de Variables Globales
    [Header("Variables de Salud")]
    //Vida maxima
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private Image _lifeBar;
    //Vida actual
    private float _currentHealth;
    //Panel de Reiniciar
    [SerializeField]
    private Image _restartPanel;

    //Referencia al Spawner
    private EnemySpawnerManager _spawner;

    //Collider del tanque
    private Collider _collider;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _collider = GetComponent<Collider>();
        _spawner = FindObjectOfType<EnemySpawnerManager>();
    }

    void Update()
    {
        _lifeBar.fillAmount = _currentHealth / _maxHealth;
    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        if (infoCollision.collider.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        //Se reduce la vida
        _currentHealth = _currentHealth - 1;

        //Si la vida es menor o igual a 0
        if (_currentHealth <= 0)
        {
            //Si el objeto es un enemigo
            if (this.gameObject.CompareTag("PlayerTank"))
            {
                //Activa el metodo de muerte
                Die();
            }
            else
            {
                //Destruye el objeto
                Destroy(this.gameObject);
            }
        }
    }

    private void Die()
    {
        //Paramos el tiempo
        Time.timeScale = 0;

        //Sale el panel de reinicio
        _restartPanel.gameObject.SetActive(true);
    }
}
