using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = -1.0f;
    private void Update()
    {
        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
        //OnTriggerEnter(gameObject.GetComponent<BoxCollider2D>());
    }

    void OnTriggerEnter(Collider hit)
    {
        print("qwerfd");
        if (hit.CompareTag("Enemy"))
        {
            print("fffff");
        }
    }
}
