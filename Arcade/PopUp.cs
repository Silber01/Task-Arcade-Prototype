using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    string game = "HomeScene";
    readonly int BLOCK_BREAKER_COST = 2;
    readonly int LASER_DEFENCE_COST = 2;
    readonly int COWBOY_COST = 2;
    [SerializeField] TextMeshProUGUI popUpText;
    [SerializeField] ArcadeLoader arcadeLoader;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    [SerializeField] Button okButton;
    Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
    Vector3 offScreen = new Vector3(Screen.width * -2, 0, 0);
    [SerializeField] TokenSystem tokenSystem;
    int tokensRequired = 0;


    private void Awake()
    {
        tokenSystem = FindObjectOfType<TokenSystem>();
        okButton.gameObject.SetActive(false);
    }
    public void LoadBlockBreaker()
    {
        tokensRequired = BLOCK_BREAKER_COST;
        if (tokenSystem.getTokens() >= tokensRequired)
        {
            popUpText.text = "Would you like to play Block Breaker for " + BLOCK_BREAKER_COST + " tokens?";
            gameObject.transform.position = center;
            game = "Block Breaker";
        }
        else
        {
            NotEnoughTokens();
        }
        
    }
    public void LoadLaserDefence()
    {
        tokensRequired = LASER_DEFENCE_COST;
        if (tokenSystem.getTokens() >= tokensRequired)
        {
            popUpText.text = "Would you like to play Laser Defense for " + LASER_DEFENCE_COST + " tokens?";
            gameObject.transform.position = center;
            game = "Laser Defense";
        }
        else
        {
            NotEnoughTokens();
        }
    }
    public void LoadCowboy()
    {
        tokensRequired = COWBOY_COST;
        if (tokenSystem.getTokens() >= tokensRequired)
        {
            popUpText.text = "Would you like to play The Adventures of Chuck & Django for " + COWBOY_COST + " tokens?";
            gameObject.transform.position = center;
            game = "Cowboy";
        }
        else
        {
            NotEnoughTokens();
        }
    }
    public void OnYes()
    {
        if (game == "Block Breaker")
        {
            arcadeLoader.LoadBlockBreaker();
            tokenSystem.changeTokenAmountBy(-1 * tokensRequired);
        }
        else if (game == "Laser Defense")
        {
            arcadeLoader.LoadLaserDefense();
            tokenSystem.changeTokenAmountBy(-1 * tokensRequired);
        }
        else if (game == "Cowboy")
        {
            arcadeLoader.LoadCowboy();
            tokenSystem.changeTokenAmountBy(-1 * tokensRequired);
        }
        else
        {
            Debug.Log("Game Not Selected?");
        }
    }
    public void OnNo()
    {
        gameObject.transform.position = offScreen;
    }
    public void OnOK()
    {
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        okButton.gameObject.SetActive(false);
        gameObject.transform.position = offScreen;
    }
    private void NotEnoughTokens()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        okButton.gameObject.SetActive(true);
        popUpText.text = "You do not have enough tokens. Do tasks in your planner to earn tokens.";
        gameObject.transform.position = center;
    }

    
}
