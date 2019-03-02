using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStars : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] int addedStars = 3;
    [SerializeField] ParticleSystem addStarsEffect;
    [SerializeField] GameObject pivot;
#pragma warning restore 649

    public void AddStarsToStash() {
        FindObjectOfType<StarDisplay>().AddStars(addedStars);
        if (addStarsEffect) Instantiate(addStarsEffect,
            (pivot!=null ? pivot.transform.position : transform.position),
            Quaternion.identity);
    }
}
