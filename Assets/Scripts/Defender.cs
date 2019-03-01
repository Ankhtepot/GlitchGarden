using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private GameObject projectile;
    [SerializeField] int cost;

    public int Cost { get => cost; }
#pragma warning restore 649



    public void Shoot()
    {
        if(projectile) Instantiate(projectile, transform.position, transform.rotation);
    }
}
