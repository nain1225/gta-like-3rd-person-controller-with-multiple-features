using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDamageCount : MonoBehaviour
{
    public float TotalHealth = 120f;
    

    public void DamageCount(float amount)
    {
        TotalHealth -= amount;

        if(TotalHealth <= 0 )
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
