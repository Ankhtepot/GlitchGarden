using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
#pragma warning disable 649
    [Range(0f, 3f)] [SerializeField] private float walkingSpeed;
    [SerializeField] private float walkingSpeedActual;
    [SerializeField] int healthPoints;
    [SerializeField] int attackPower;
    [SerializeField] ParticleSystem deathEffect;
#pragma warning restore 649

    void Start()
    {
        walkingSpeedActual = 0f;
    }

    void Update()
    {
        transform.Translate(Vector2.left * walkingSpeedActual * Time.deltaTime);
    }

    public void SetWalkingSpeed(float newSpeed)
    {
        walkingSpeedActual = newSpeed;
    }    

    private void OnTriggerEnter2D(Collider2D collision) {
        print("Triggered with: " + collision.gameObject.name);
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile) {
            reduceHP(projectile.getAttackPower());
            projectile.takeDamage(attackPower);
        }
    }

    private void reduceHP(int damage) {
        healthPoints -= damage;
        if (healthPoints <= 0) Die();
    }

    private void Die() {
        if(deathEffect) Instantiate(deathEffect, transform.position, Quaternion.identity).Play();
        Destroy(gameObject);
    }
}
