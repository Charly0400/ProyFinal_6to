using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score = 0;
    private void OnTriggerEnter(Collider other) {
        score++;
        text.text = "Score: " + score;
        Destroy(other.gameObject);
    }
}
