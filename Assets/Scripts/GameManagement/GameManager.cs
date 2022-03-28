using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject rival;
    GameObject exit;
    //TO DO : Move to school day controller script

    void Start()
    {
        rival = GameObject.FindGameObjectWithTag("Rival");
        rival.GetComponent<Rival>().onRivalDeath += EnableExit;
        exit = GameObject.FindGameObjectWithTag("Exit");
        exit.SetActive(false);
        exit.GetComponent<Exit>().onPlayerExit += ReloadScene;
    }

    void EnableExit()
    {
        exit.SetActive(true);
    }
    //TO DO : Move to separate script
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
