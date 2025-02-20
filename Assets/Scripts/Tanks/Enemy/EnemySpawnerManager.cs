using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{

    //Zona de Variables Globales
    [Header("Variables de Spawn")]
    //Puntos de spawn
    [SerializeField]
    private Transform[] _spawnPoints;
    //Prefab del enemigo
    [SerializeField]
    private GameObject _enemyPrefab;
    //Tiempo entre spawns
    [SerializeField]
    private float _timeBetweenSpawns;
    //Temporizador
    private float _timer;
    //Cantidad maxima de enemigos
    [SerializeField]
    private int _maxEnemies;
    //Cantidad actual de enemigos
    private int _currentEnemies;

    void Update()
    {
        CountTimer();
    }

    private void CountTimer()
    {
        //Sumar tiempo al temporizador
        _timer += Time.deltaTime;

        //Si el temporizador es mayor al tiempo entre spawns
        if (_timer >= _timeBetweenSpawns)
        {
            //Reseteamos el temporizador
            _timer = 0;
            //Llamamos al metodo de spawn
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        //Si la cantidad de enemigos es menor a la cantidad maxima de enemigos
        if (_currentEnemies < _maxEnemies)
        {
            //Seleccionamos un punto de spawn aleatorio entre 0 y
            //la cantidad de puntos de spawn
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            //Establecemos el punto de spawn
            Transform spawnPoint = _spawnPoints[spawnPointIndex];

            //Instanciamos el enemigo en el punto de spawn
            Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            //Aumentamos la cantidad de enemigos
            _currentEnemies++;
        }
    }
}
