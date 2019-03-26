using Assets.Scripts.constants;
using System;
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
    //cant change parent to prefab but leaving here for inspiration
    GameObject ProjectileParent;
#pragma warning restore 649

    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        //cant change parent to prefab but leaving here for inspiration
        CreateProjectileParent();
    }

    //cant change parent to prefab but leaving here for inspiration
    private void CreateProjectileParent() 
    {
        ProjectileParent = GameObject.Find(system.PROJECTILES_PARENT);
        if(!ProjectileParent)
        {
            ProjectileParent = new GameObject(system.PROJECTILES_PARENT);
        }
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
        if (!myLaneSpawner) return false;
        return myLaneSpawner.transform.childCount > 0;
    }

    private void Update() {
        animator.SetBool(triggers.ISATTACKING, isAttackerInLane());
    }

    public void Shoot() {
        if (projectile)
        {
            Projectile newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            //cant change parent to prefab but leaving here for inspiration
            //projectile.transform.parent = ProjectileParent.transform;
        }
    }
}
