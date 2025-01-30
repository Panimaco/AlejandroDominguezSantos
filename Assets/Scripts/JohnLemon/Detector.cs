using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    //Zona de Variables Globales
    public GameManager GameManagerScript;

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("JohnLemon"))
        {
            GameManagerScript.IsPlayerCaught = true;
        }
    }
}
