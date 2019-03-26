using Assets.Scripts.constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
#pragma warning disable 649

    [SerializeField] int cost;
    [SerializeField] Animator animator;
    Vector2 position;

    public int Cost { get => cost; }
#pragma warning restore 649

    private void Start()
    {
        position = transform.position;
    }

    public void ReactionOnAttack() {
        if (animator) animator.SetTrigger(triggers.ATTACKED);
    }

    public void LoseProcess(Vector2 position)
    {
        FindObjectOfType<DefenderSpawner>().FreeSquare(position);
    }
}
