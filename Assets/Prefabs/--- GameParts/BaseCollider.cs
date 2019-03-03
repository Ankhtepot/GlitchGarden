using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class BaseCollider : MonoBehaviour
{
#pragma warning disable 649
#pragma warning restore 649
    [SerializeField] ParticleSystem losingPlayerHealthVFX;
    [SerializeField] PlayerHealthText healthText;
    [SerializeField] Health health;
    [SerializeField] float destroyAttackerDelay = 0.5f;

    private void Start() {
        health = GetComponent<Health>();
        assignHealthText();
        healthText.UpdateText(health.getHealthpoints());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        print("Triggered");
        GameObject otherObject = collision.gameObject;
        if(otherObject.GetComponent<Attacker>()) {
            GetComponent<Health>().ReceiveDamage(1);
            healthText.UpdateText(health.getHealthpoints());
            if (losingPlayerHealthVFX) Instantiate(losingPlayerHealthVFX, collision.transform.position, Quaternion.identity);
            Destroy(otherObject, destroyAttackerDelay);
        }
    }

    public void LoseProcess() {
        print("I lost");
        SceneLoader SC = FindObjectOfType<SceneLoader>();
        SC.LoadGameOverScreen();
    }

    private void assignHealthText() {
        while(!healthText) {
            healthText = GetComponent<PlayerHealthText>();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision) {
    //    print("Collided");
    //        GameObject otherObject = collision.gameObject;
    //        if (otherObject.GetComponent<Attacker>()) {
    //            GetComponent<Health>().ReceiveDamage(1);
    //            healthText.UpdateText(health.getHealthpoints());
    //        Destroy(otherObject);
    //        }
    //}
}
