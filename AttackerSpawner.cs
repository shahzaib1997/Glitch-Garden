using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 7f, maxSpawnDelay = 12f;
    [SerializeField] Attacker[] attackerPrefabArray;

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

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawn == false)
            {
                StopCoroutine(Start());
            }
            else
            {
                SpawnAttacker();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeTier();
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }

    private void SetTimeTier()
    {
        if(Time.timeSinceLevelLoad >= tier1Time && !tier1Triggered)
        {
            minSpawnDelay = 7f;
            maxSpawnDelay = 12f;
            tier1Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier2Time && !tier2Triggered)
        {
            minSpawnDelay = 6f;
            maxSpawnDelay = 11f;
            tier2Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier3Time && !tier3Triggered)
        {
            minSpawnDelay = 5f;
            maxSpawnDelay = 10f;
            tier3Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier4Time && !tier4Triggered)
        {
            minSpawnDelay = 4f;
            maxSpawnDelay = 9f;
            tier4Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier5Time && !tier5Triggered)
        {
            minSpawnDelay = 4f;
            maxSpawnDelay = 8f;
            tier5Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier6Time && !tier6Triggered)
        {
            minSpawnDelay = 3f;
            maxSpawnDelay = 7f;
            tier6Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier7Time && !tier7Triggered)
        {
            minSpawnDelay = 3f;
            maxSpawnDelay = 6f;
            tier7Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier8Time && !tier8Triggered)
        {
            minSpawnDelay = 2f;
            maxSpawnDelay = 4f;
            tier8Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier9Time && !tier9Triggered)
        {
            minSpawnDelay = 2f;
            maxSpawnDelay = 3f;
            tier9Triggered = true;
        }
        if(Time.timeSinceLevelLoad >= tier10Time && !tier10Triggered)
        {
            minSpawnDelay = 1.5f;
            maxSpawnDelay = 2.7f;
            tier10Triggered = true;
        }
    }
}
