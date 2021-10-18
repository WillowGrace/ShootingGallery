using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathPack : MonoBehaviour
{
    void OnTriggerEnter(Collider collid)
    {
        // player health + 5 
        if (collid.name == "Player")
        {
            Debug.Log("Heal up!");
             Destroy(gameObject);
        }
            

    }
}
