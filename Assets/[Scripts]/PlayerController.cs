using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform, joystickTransform, cameraTransform;
    private Vector2 pointA;
    private Vector2 pointB;
    public int coneShots;

    private Vector3 relativePos1, 
        relativePos2, 
        relativePos3;

    public int playerMaxHealth = 100,
        playerHealth;

    public GameObject bulletPrefab;


    public Vector3 playerDirection;

    [SerializeField]
    public LayerMask wallMask, buttonMask;

    public float speed = 5.0f;
    public float projectileSpeed = 5.0f;

    public float tpDistance = 3;
    private bool touchStart = false;
// Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //RaycastHit hit;
            //var worldTouchPos = Camera.main.ScreenToWorldPoint((Vector3) touch.position);
            if (!EventSystem.current.IsPointerOverGameObject((touch.fingerId)))
            {
                joystickTransform.GetComponent<SpriteRenderer>().enabled = true;
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        pointA = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            Camera.main.transform.position.z));
                        joystickTransform.position = pointA;
                        break;

                    case TouchPhase.Moved:
                        touchStart = true;
                        joystickTransform.GetComponent<SpriteRenderer>().enabled = true;
                        pointB = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            Camera.main.transform.position.z));
                        break;
                }
            }
        }
        else
            touchStart = false;
    }

    private void FixedUpdate()
    {
        Vector2 offset = pointB - pointA;
        Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
        playerDirection = (Vector3)direction;
       
        if (touchStart == true)
        {

            MovePlayer(direction);
            joystickTransform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            joystickTransform.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void TeleportInDirection()
    {
        
        RaycastHit2D tpHitRay;
        //Vector3 direction = (pointB - pointA).normalized;
        tpHitRay = Physics2D.Raycast(playerTransform.position, playerDirection, tpDistance, wallMask);

        if (tpHitRay.collider != null)
        {
            playerTransform.position = tpHitRay.point;
        }
        else
        {
            playerTransform.position += playerDirection * tpDistance;
        }
        //playerTransform.position = direction * tpDistance;
        Debug.Log("Teleported");
    }

    void MovePlayer(Vector2 direction)
    {
        playerTransform.Translate(direction * speed * Time.deltaTime);

    }

    public void ConeProjectileShoot()
    {
        var newVector = Quaternion.AngleAxis(15, Vector3.forward) * playerDirection;
        var newVector2 = Quaternion.AngleAxis(-15, Vector3.forward) * playerDirection;

        var newBullet = Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
        var newBullet2 = Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
        var newBullet3 = Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);

        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = newBullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = newBullet3.GetComponent<Rigidbody2D>();

        rb.AddForce(newVector * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
        rb2.AddForce(newVector2 * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
        rb3.AddForce(playerDirection * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void LaserProjectileShot()
    {

    }
    void OnDrawGizmos()
    {

    }

}
