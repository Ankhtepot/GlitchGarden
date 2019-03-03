using Assets.Scripts.constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
#pragma warning disable 649
    
    [SerializeField] int cost;
    [SerializeField] Animator animator;

    public int Cost { get => cost; }
#pragma warning restore 649

    public void ReactionOnAttack() {
       if(animator) animator.SetTrigger(triggers.ATTACKED);
    }
    
}
