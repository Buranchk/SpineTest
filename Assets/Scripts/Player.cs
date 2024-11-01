using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void OnTriggerEnter(Collider hit)
    {
            print("qwerfd");
        if (hit.CompareTag("Enemy"))
        {
            print("fffff");
        }
    }
}
