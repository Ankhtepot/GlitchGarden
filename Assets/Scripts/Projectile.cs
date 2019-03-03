using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum Directions {
        Right, Left
    }

#pragma warning disable 649
    [SerializeField] Directions directionPreset = Directions.Right;
    [SerializeField] float movementSpeed;
    [SerializeField] int attackPower;
    [SerializeField] int healthPoints;
    [SerializeField] float lifetime = 5f;
#pragma warning restore 649

    //Caches
    Vector3 direction;

    private void Start() {
        direction = getDirection();
        Destroy(gameObject, lifetime);
    }

    private void Update() {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private Vector3 getDirection() {
        Vector3 result = Vector3.zero;
        switch(directionPreset) {
            case (Directions.Right): return new Vector3(1,0,0);
            case (Directions.Left): return Vector3.left;
        }
        return result;
    }

    public int getAttackPower() {
        return attackPower;
    }

    public void takeDamage(int damage) {
        healthPoints -= damage;
        if (healthPoints <= 0) Die();
    }

    private void Die() {
        Destroy(gameObject);
    }
}
