using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //private Transform target;
    //public Collider2D fireBallCollider;
    // Start is called before the first frame update
    void Start()
    {
        //fireBallCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(15);
        }
    }
}
