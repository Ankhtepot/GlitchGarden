using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStars : MonoBehaviour
{
    [SerializeField] int addedStars = 3;
    [SerializeField] ParticleSystem addStarsEffect;
    [SerializeField] GameObject pivot;

    public void AddStarsToStash() {
        FindObjectOfType<StarDisplay>().AddStars(addedStars);
        if (addStarsEffect) Instantiate(addStarsEffect,
            (pivot!=null ? pivot.transform.position : transform.position),
            Quaternion.identity);
    }
}
