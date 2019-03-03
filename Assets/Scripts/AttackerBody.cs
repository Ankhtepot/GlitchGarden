using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBody : MonoBehaviour
{
    [SerializeField] Attacker attacker;

    private void Start() {
        attacker = GetComponentInParent<Attacker>();
    }

    public void SetWalkingSpeed(float newSpeed) {
        attacker.SetWalkingSpeed(newSpeed);
    }

    public void StrikeCurrentTarget() {
        attacker.StrikeCurrentTarget();
    }
}
