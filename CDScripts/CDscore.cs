using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CDscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int scoreValue = 0;

    private void Start()
    {
        scoreText.text = scoreText.text = "Score: " + scoreValue.ToString();
    }
    public void increaseScore(int increment)
    {
        scoreValue += increment;
        scoreText.text = "Score: " + scoreValue.ToString();
    }
}
