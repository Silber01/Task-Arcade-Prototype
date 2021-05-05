using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LDGameOverHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tokenText;
    [SerializeField] TokenSystem tokenSystem;
    [SerializeField] Button PlayAgainButton;
    [SerializeField] TextMeshProUGUI PlayAgainText;
    readonly int TOKENS_REQUIRED = 2;

    private void Awake()
    {
        tokenSystem = FindObjectOfType<TokenSystem>();
    }
    void Start()
    {
        tokenText.text = "Tokens: " + tokenSystem.getTokens();
        if (tokenSystem.getTokens() >= TOKENS_REQUIRED)
        {
            PlayAgainText.text = "Play Again (" + TOKENS_REQUIRED + " Tokens)";
        }
        else
        {
            PlayAgainButton.gameObject.SetActive(false);
        }
    }

    public void onPlayAgain()
    {
        tokenSystem.changeTokenAmountBy(TOKENS_REQUIRED * -1);
        SceneManager.LoadScene("Laser Defense");
    }
    public void onQuit()
    {
        SceneManager.LoadScene("Arcade");
        MusicPlayer destroyMe = FindObjectOfType<MusicPlayer>();
        destroyMe.DestroyMusic();
    }
}

