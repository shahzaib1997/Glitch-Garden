using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            TriggerDeathVfx();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVfx()
    {
        if(!deathVFX)
        {
            return;
        }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 2f);
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }
}
