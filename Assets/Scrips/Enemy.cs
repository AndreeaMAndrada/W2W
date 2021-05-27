using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;//Health
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreManager.instance.AddPoint();//adds in stance of the score keeper 
        }
    }
    public void TakeDamage(int damage)//from projectile class it gets the info from there
    {
        health -= damage; //substract dmg from health
       
    }
}

