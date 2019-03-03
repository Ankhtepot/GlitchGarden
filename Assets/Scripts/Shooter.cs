﻿using Assets.Scripts.constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] AttackerSpawner[] attackerSpawners;
    [SerializeField] AttackerSpawner myLaneSpawner;
    [SerializeField] Animator animator;
#pragma warning disable 649
    [SerializeField] Projectile projectile;
#pragma warning restore 649

    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner() {
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attackerSpawners) {
            bool isCLoseEnough = (Mathf.Abs(spawner.transform.position.y - GetComponentInParent<Defender>().transform.position.y) <= Mathf.Epsilon);
            if (isCLoseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool isAttackerInLane() {
        return myLaneSpawner.transform.childCount > 0;
    }

    private void Update() {
        animator.SetBool(triggers.ISATTACKING, isAttackerInLane());
    }

    public void Shoot() {
        if (projectile) Instantiate(projectile, transform.position, transform.rotation);
    }
}