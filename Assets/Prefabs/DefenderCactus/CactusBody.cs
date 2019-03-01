using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBody : MonoBehaviour
{
    public void Shoot() {
        GetComponentInParent<Defender>().Shoot();
    }   
}
