using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    float tier1Time = 0f;
    float tier2Time = 30f;
    float tier3Time = 60f;
    float tier4Time = 90f;
    float tier5Time = 120f;
    float tier6Time = 135f;
    float tier7Time = 180f;
    float tier8Time = 210f;
    float tier9Time = 240f;
    float tier10Time = 270f;

    bool tier1Triggered = false;
    bool tier2Triggered = false;
    bool tier3Triggered = false;
    bool tier4Triggered = false;
    bool tier5Triggered = false;
    bool tier6Triggered = false;
    bool tier7Triggered = false;
    bool tier8Triggered = false;
    bool tier9Triggered = false;
    bool tier10Triggered = false;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
        SetHealthTier();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }

    private void SetHealthTier()
    {
        if(Time.timeSinceLevelLoad >= tier1Time && !tier1Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(300f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(200f);
            }
            tier1Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier2Time && !tier2Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(300f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(200f);
            }
            tier2Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier3Time && !tier3Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(400f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(300f);
            }
            tier3Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier4Time && !tier4Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(400f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(300f);
            }
            tier4Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier5Time && !tier5Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(500f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(400f);
            }
            tier5Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier6Time && !tier6Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(600f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(500f);
            }
            tier6Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier7Time && !tier7Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(700f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(600f);
            }
            tier7Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier8Time && !tier8Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(700f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(600f);
            }
            tier8Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier9Time && !tier9Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(700f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(600f);
            }
            tier9Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier10Time && !tier10Triggered)
        {
            if(GetComponent<Lizard>())
            {
                GetComponent<Health>().SetHealth(700f);
            }
            else if(GetComponent<Fox>())
            {
                GetComponent<Health>().SetHealth(600f);
            }
            tier10Triggered = true;
        }
    }
}
