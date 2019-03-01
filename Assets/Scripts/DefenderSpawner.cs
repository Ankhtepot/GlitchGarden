using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Defender defender;
#pragma warning restore 649

    private void OnMouseDown() {
        //print("Mouse was clicked on location: " + processedCoordinate);
        SpawnSelected(getClickedSquare(Input.mousePosition));
    }

    private void SpawnSelected(Vector2 worldPosition) {
        Defender newDefender = defender;
        if (defender)  newDefender = Instantiate(defender, worldPosition, Quaternion.identity) as Defender;
    }

    private Vector2 getClickedSquare(Vector2 clickPosition) {
        var screenPoint = Camera.main.ScreenToWorldPoint(clickPosition);
        return new Vector3(Mathf.Ceil(screenPoint.x - 0.5f),
            Mathf.Ceil(screenPoint.y - 0.5f),
            screenPoint.z);
    }

    public void SetSelectedDefender(Defender newDefender) {
        defender = newDefender;
    }
}
