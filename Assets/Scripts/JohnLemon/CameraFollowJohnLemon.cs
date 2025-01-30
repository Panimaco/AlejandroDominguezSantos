using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJohnLemon : MonoBehaviour
{
    //Zona de Variables Globales
    public Transform Target;
    [Header("Vectors")]
    [SerializeField]
    private float _smoothing;
    //Distancia inicial entre la camara y el "player"
    [SerializeField]
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        
        _offset = transform.position - Target.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Direccion a la que queremos mover la camara
        Vector3 desiredPosition = Target.position + _offset;

        //Movemos la camara
        transform.position = Vector3.Lerp(transform.position, 
                desiredPosition, _smoothing * Time.deltaTime);
    }
}
