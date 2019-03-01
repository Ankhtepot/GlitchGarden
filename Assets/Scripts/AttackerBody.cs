using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBody : MonoBehaviour
{
    public void SetWalkingSpeed(float newSpeed) {
        GetComponentInParent<Attacker>().SetWalkingSpeed(newSpeed);
    }
}
