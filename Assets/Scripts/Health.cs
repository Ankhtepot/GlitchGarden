using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] int healthPoints;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] LevelController GC;
#pragma warning disable 649

    private void Start()
    {
        GC = FindObjectOfType<LevelController>();
    }

    public void ReceiveDamage(int damage) {
        healthPoints -= damage;
        if (healthPoints <= 0) Die();
    }

    private void Die() {
        if (GetComponent<BaseCollider>()) GetComponent<BaseCollider>().LoseProcess();
        if (GetComponent<Defender>()) GetComponent<Defender>().LoseProcess(transform.position);
        else if (deathVFX) Instantiate(deathVFX, transform.position, Quaternion.identity).Play();
       
        Destroy(gameObject);
    }

    public int getHealthpoints() {
        return healthPoints;
    }
}
