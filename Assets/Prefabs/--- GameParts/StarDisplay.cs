using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 200;
    [SerializeField] TextMeshProUGUI starText;

    public int Stars { get => stars; set => stars = value; }

    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        updateDisplay();
    }

    private void updateDisplay() {
        starText.text = Stars.ToString();
    }

    public void AddStars(int addedStars) {
        Stars += addedStars;
        updateDisplay();
    }

    public void ReduceStars(int deductedStars) {
        if (Stars >= deductedStars) {
            Stars -= deductedStars;
            updateDisplay();
        }
    }

}
