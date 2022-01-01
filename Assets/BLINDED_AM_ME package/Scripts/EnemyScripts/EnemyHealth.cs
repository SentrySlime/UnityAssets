using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    Enemy_Navmesh enemyNavigation;

    int maxHealth = 100;
    public int currentHealth = 0;

    public bool dead = false;

    void Start()
    {
        ToMaxHealth();
        enemyNavigation = GetComponent<Enemy_Navmesh>();
    }

    void Update()
    {
        
    }

    public void TakeDamage(int incomingDamage)
    {
        currentHealth -= incomingDamage;
        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        dead = true;
        enemyNavigation.canMove = false;
    }

    public void ToMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void Revive()
    {
        ToMaxHealth();
        dead = false;
    }

}
