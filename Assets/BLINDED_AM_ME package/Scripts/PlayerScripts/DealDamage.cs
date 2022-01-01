using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Damage(EnemyHealth enemy, int damage)
    {
        enemy.TakeDamage(damage);
    }
}
