using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] 
public class DefenderButton : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Color offColor;
    [SerializeField] Color onColor;
    [SerializeField] public bool isOn;
    [SerializeField] public Defender spawnedObject;
#pragma warning restore 649

    private void OnMouseDown() {
        AllDefenderButtonsOff();
        ChangeState(true);    
    }

    public void ChangeState(bool state) {
        if(state) {
            if(onColor != null) GetComponent<SpriteRenderer>().color = onColor;
            isOn = true;
        } else {
            if(offColor != null) GetComponent<SpriteRenderer>().color = offColor;
            isOn = false;
        };
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(spawnedObject);
    }

    public void AllDefenderButtonsOff() {
        foreach (DefenderButton button in FindObjectsOfType<DefenderButton>()) {
            if(button.isOn) button.ChangeState(false);
        }
    }

    public int GetSpawnedObjectStarCost() {
        if (spawnedObject) return spawnedObject.Cost;
        print("DefenderButton/GetSpawnedObjectCost: spawnedObject is not assigned or has no cost set.");
        return 0;
    }
}
