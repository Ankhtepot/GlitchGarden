using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    //TODO: check is clickedSquareIsOccupied is necesarry still, keeping there for now as safecheck mechanism
#pragma warning disable 649
    [SerializeField] Defender defender;
    [SerializeField] List<Vector2> occupiedGridSquares = new List<Vector2>();
#pragma warning restore 649

    private void OnMouseDown() {
        //print("Mouse was clicked on location: " + processedCoordinate);
        SpawnSelected(getClickedSquare(Input.mousePosition));
    }

    private void SpawnSelected(Vector2 worldPosition) {
        Defender newDefender = defender;
        if (!defender) return;
        if (hasEnoughStars(defender.Cost) && !isClickedSquareOccupied(worldPosition)) {
            occupiedGridSquares.Add(worldPosition);
            FindObjectOfType<StarDisplay>().ReduceStars(defender.Cost);
            newDefender = Instantiate(defender, worldPosition, Quaternion.identity) as Defender;
        }
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

    private bool hasEnoughStars(int cost) {
        return FindObjectOfType<StarDisplay>().Stars >= cost;
    }

    private bool isClickedSquareOccupied(Vector2 checkedSquare) {
        // print("Clicked square is occupied: " + occupiedGridSquares.Contains(checkedSquare));
        return occupiedGridSquares.Contains(checkedSquare);
    }

    public void FreeSquare(Vector2 square)
    {
        occupiedGridSquares.RemoveAll(contained => contained == square);
    }
}
