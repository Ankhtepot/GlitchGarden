using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] public bool spawn = true;
    [SerializeField] private float minTimeToSpawn = 1;
    [SerializeField] private float maxTimeToSpawn = 5;
#pragma warning disable 649
    [SerializeField] private Attacker[] attackers;
    [SerializeField] LevelController GC;
#pragma warning restore 649

    //Caches
    private const int SPAWNERCOUNT = 5;

    IEnumerator Start()
    {
        if (!GC) GC = FindObjectOfType<LevelController>();
        
        yield return manageAttackerSpawn();
    }

    private IEnumerator manageAttackerSpawn()
    {
        while (spawn)
        {
            yield return new WaitForSecondsRealtime(Random.Range(minTimeToSpawn, maxTimeToSpawn));
            spawnEnemy();
        }
    }

    void Update()
    {
        if (!spawn) return;
    }

    private void spawnEnemy()
    {
        if (attackers.Length == 0) return;

        Attacker newAttacker = Instantiate(
            attackers[Random.Range(0, attackers.Length)], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
        
    }

    public void StopSpawning()
    {
        print("Stopping spawning in spawner");
        spawn = false;
    }
}
