using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSystem : MonoBehaviour
{
    int tokens = 0;
    private void Awake()
    {
        int tokenSystemCount = FindObjectsOfType<TokenSystem>().Length;
        if (tokenSystemCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int getTokens()
    {
        return tokens;
    }    
    public void changeTokenAmountBy(int amount)
    {
        tokens += amount;
    }    

}
