using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private GameObject projectile;
#pragma warning restore 649

    public void Shoot() {
        if (projectile) Instantiate(projectile, transform.position, transform.rotation);
    }
}
