using Assets.Scripts.constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] Defender target;
    [SerializeField] Animator animator;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Defender>()) target = collision.gameObject.GetComponent<Defender>();
        else return;

        if(target.GetComponent<Gravestone>()) {
            animator.SetTrigger(triggers.JUMP);
        } else {
            GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }
}
