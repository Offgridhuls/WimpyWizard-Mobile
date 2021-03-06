using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public bool alive;
    //public HealthBarBehaviour healthBar;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
       // healthBar.SetHealth(curHealth, maxHealth);
    }

    private void Update()
    {
       if(curHealth <= 0)
        {
            curHealth = 0;
        }

       if(curHealth == 0)
        {
            Destroy(gameObject);
        }
       if(gameObject.tag == "Player" && curHealth == 0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        //healthBar.SetHealth(curHealth, maxHealth);
    }
}
