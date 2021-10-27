using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExample : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 vel;
    public Vector3 dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
    
    }
    public void ConeProjectileShot()
    {

    }
}
