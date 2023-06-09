using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float health = 4f;

    public static int EnemiesAlive = 0;

       
    // Start is called before the first frame update
    void Start()
    {
        
        


        EnemiesAlive++;
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();

        }        
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
                EnemiesAlive--;
        
        if (EnemiesAlive <= 0)
        {
            
            Debug.Log("LEVEL WON!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
           

        Destroy(gameObject);

       
    }
}
