using Assets.Scripts.constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Attacker : MonoBehaviour
{
#pragma warning disable 649
    [Range(0f, 3f)] [SerializeField] private float walkingSpeed;
    [SerializeField] private float walkingSpeedActual;
    [SerializeField] int attackPower;
    [SerializeField] GameObject currentTarget;
    [SerializeField] Animator animator;
#pragma warning restore 649

    void Start()
    {
        walkingSpeedActual = 0f;
        animator = GetComponentInChildren<Animator>();
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
       // print("Triggered with: " + collision.gameObject.name);
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile) {
            reduceHP(projectile.getAttackPower());
            projectile.takeDamage(attackPower);
        }
    }

    private void reduceHP(int damage) {
        GetComponent<Health>().ReceiveDamage(damage);
    }

    public void Attack(GameObject target) {
        animator.SetBool(triggers.ATTACK, true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget() {
        if (!currentTarget) {
            animator.SetBool(triggers.ATTACK, false);
            return;
        }
        if (currentTarget.GetComponent<Defender>()) {
            currentTarget.GetComponent<Defender>().ReactionOnAttack();
        }
        Health health = currentTarget.GetComponent<Health>();
        if(health) {
            health.ReceiveDamage(attackPower);
        }
    }
}
