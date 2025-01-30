using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //Zona de Variables Globales
    [Header("WayPoints")]
    //Array de posiciones para la patrulla
    [SerializeField]
    private Transform[] _positionsArray;
    [SerializeField]
    private float _speed;
    //Almacenar la posicion a la que se dirige el fantasma
    private Vector3 _posToGo;
    //Indice para controlar en que posicion del "array" estoy
    private int _i;
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _i = 0;
        _posToGo = _positionsArray[_i].position;
    }

    private void FixedUpdate()
    {
        DetectionJohnLemon();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangePosition();
        Rotate();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _posToGo,
                                                 _speed * Time.deltaTime);
    }
    private void ChangePosition()
    {
        //Si el fantasma ha llegado a su destino
        if (Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {

            if (_i == _positionsArray.Length - 1)
            {
                _i = 0;

            }
            else
            {
                _i++;
            }
            _posToGo = _positionsArray[_i].position;
        }
    }
    private void Rotate()
    {
        transform.LookAt(_posToGo);
    }

    private void DetectionJohnLemon()
    {

        //Subir el origen del rayo en un metro en el y
        _ray.origin = new Vector3(transform.position.x, transform.position.y
                                  + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("JohnLemon"))
            {
                GameManagerScript.IsPlayerCaught = true;
            }
        }
    }
}
