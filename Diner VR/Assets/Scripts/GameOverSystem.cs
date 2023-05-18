using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverSystem : MonoBehaviour
{
    public TextMeshProUGUI finalScore;

    void Update()
    {
        finalScore.text = "FINAL BILL: " + "$" + WavesSystem.instance.randomFinalScoreValue.ToString();
    }
}
