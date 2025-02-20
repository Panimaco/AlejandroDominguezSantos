using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //Zona de variables globales
    [SerializeField]
    private GameObject _player;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("PlayerTank");
    }

    void Update()
    {
        if(!_player)
        {
            return;
        }

        GetPlayer();
    }

    private void GetPlayer()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
