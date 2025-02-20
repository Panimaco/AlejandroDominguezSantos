using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankSceneManager : MonoBehaviour
{
    public void ReloadScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
}
