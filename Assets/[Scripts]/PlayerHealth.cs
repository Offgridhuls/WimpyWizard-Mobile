using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        if (curHealth <= 0)
        {
            curHealth = 0;
        }

        if (curHealth == 0)
        {

            SceneManager.LoadScene("Gameover");
        }
        
    }
    
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        //healthBar.SetHealth(curHealth, maxHealth);
    }
   
}
