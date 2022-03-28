using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Exit : MonoBehaviour
{
    public event Action onPlayerExit;
   private void OnTriggerEnter(Collider other) {
       if(other.tag == "Player")
       {
           if(onPlayerExit != null)
           {
               onPlayerExit();
           }
       }
   }
}
