using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CDGameOverHandler : MonoBehaviour
{
    [SerializeField] TokenSystem tokenSystem;
    [SerializeField] SceneLoader sceneLoader;
    readonly int TOKENS_REQUIRED = 2;
    [SerializeField] TextMeshProUGUI tokenText;
    [SerializeField] Button PlayAgain;

    private void Awake()
    {
        tokenSystem = FindObjectOfType<TokenSystem>();
    }
    void Start()
    {
        tokenText.text = "Tokens: " + tokenSystem.getTokens();
        if (tokenSystem.getTokens() >= TOKENS_REQUIRED)
        {
            PlayAgain.gameObject.SetActive(true);
        }
        else
        {
            PlayAgain.gameObject.SetActive(false);
        }
    }

    public void onPlayAgain()
    {
        tokenSystem.changeTokenAmountBy(TOKENS_REQUIRED * -1);
        sceneLoader.LoadCowboy();
    }
    public void onQuit()
    {
        sceneLoader.LoadArcade();
    }
}
