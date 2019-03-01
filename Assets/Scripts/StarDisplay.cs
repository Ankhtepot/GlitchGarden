using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 200;
    [SerializeField] TextMeshProUGUI starText;

    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        updateDispley();
    }

    private void updateDispley() {
        starText.text = stars.ToString();
    }

    public void AddStars(int addedStars) {
        stars += addedStars;
        updateDispley();
    }

    public void ReduceStars(int deductedStars) {
        if (stars >= deductedStars) {
            stars -= deductedStars;
        }
    }
}
