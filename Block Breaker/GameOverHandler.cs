using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tokenText;
    [SerializeField] TokenSystem tokenSystem;
    [SerializeField] Button PlayAgainButton;
    [SerializeField] TextMeshProUGUI PlayAgainText;
    [SerializeField] BBSceneLoader sceneLoader;
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
        sceneLoader.LoadBlockBreaker();
    }
    public void onQuit()
    {
        sceneLoader.LoadArcade();
    }
}
