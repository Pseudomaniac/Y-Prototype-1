using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Rival : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action onRivalDeath;
    //refactor to OnKill method

    private void OnDestroy() {
        if(onRivalDeath != null)
        {
            onRivalDeath();
            onRivalDeath = null;
        }
    }

}
