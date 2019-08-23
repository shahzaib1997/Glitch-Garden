using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float damage = 50f;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Start is called before the first frame update
    void Start()
    {
        CreateProjectileParent();
        gameObject.transform.parent = projectileParent.transform;
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        Attacker attacker = collision.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}